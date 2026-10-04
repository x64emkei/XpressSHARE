using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using XpressShare.Core;
using XpressShare.Network;
using XpressShare.Protocol;
using XpressShare.Security;
using XpressShare.Utilities;

namespace XpressShare.Transfers
{
    public class TransferManagerEventArgs : EventArgs
    {
        public TransferSession Session { get; set; }
        public TransferItem Item { get; set; }
    }

    public class TransferProgressReportEventArgs : EventArgs
    {
        public string TransferId { get; set; }
        public string FileName { get; set; }
        public double Progress { get; set; }
        public long BytesTransferred { get; set; }
        public long TotalBytes { get; set; }
        public double SpeedBytesPerSec { get; set; }
        public TimeSpan EstimatedTimeRemaining { get; set; }
    }

    public class TransferCompleteReportEventArgs : EventArgs
    {
        public string TransferId { get; set; }
        public bool Success { get; set; }
        public string FilePath { get; set; }
        public long TotalBytes { get; set; }
        public string ErrorMessage { get; set; }
    }

    /// <summary>
    /// Coordinates end-to-end file transfers using the XPX/1 protocol,
    /// dynamic performance profiles, and secure key exchanges.
    /// Compatible with .NET Framework 3.5 on Windows XP SP3 through Windows 11.
    /// </summary>
    public class TransferManager
    {
        private static readonly TransferManager _instance = new TransferManager();
        public static TransferManager Instance { get { return _instance; } }

        private readonly List<TransferSession> _activeTransfers = new List<TransferSession>();
        private readonly List<TransferItem> _transferQueue = new List<TransferItem>();
        private readonly NetworkCapabilities _networkCapabilities = new NetworkCapabilities();
        private readonly object _lock = new object();

        public event EventHandler<TransferManagerEventArgs> TransferStarted;
        public event EventHandler<TransferProgressReportEventArgs> TransferProgress;
        public event EventHandler<TransferCompleteReportEventArgs> TransferCompleted;

        public TransferManager()
        {
        }

        public void EnqueueTransfer(TransferItem item)
        {
            if (item == null) return;
            lock (_lock)
            {
                item.Status = TransferStatus.Pending;
                _transferQueue.Add(item);
            }
            AppLogger.Log("Transfer queued: " + item.FileName);
        }

        public List<TransferSession> GetActiveTransfers()
        {
            lock (_lock)
            {
                return new List<TransferSession>(_activeTransfers);
            }
        }

        public List<TransferItem> GetQueuedTransfers()
        {
            lock (_lock)
            {
                return new List<TransferItem>(_transferQueue);
            }
        }

        /// <summary>
        /// Initiates an outgoing file send session over an XPX socket.
        /// </summary>
        public TransferSession StartSendFile(
            string remoteDeviceId,
            string remoteDeviceName,
            string remoteIp,
            int remotePort,
            string filePath,
            Action<TransferSession> onStarted)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                return null;

            TransferItem item = new TransferItem(filePath, remoteDeviceId, remoteDeviceName, remoteIp, remotePort);
            item.Direction = TransferDirection.Upload;
            item.Status = TransferStatus.Negotiating;

            PerformanceProfile profile = TransferOptimizer.OptimizeTransfer(item.TotalBytes, _networkCapabilities);

            TransferSession session = new TransferSession(item, null, profile.ChunkSize);

            lock (_lock)
            {
                _activeTransfers.Add(session);
            }

            if (onStarted != null)
            {
                onStarted(session);
            }

            OnTransferStarted(session);

            // Execute on background ThreadPool thread
            ThreadPool.QueueUserWorkItem(delegate(object state)
            {
                ExecuteSendWorker(session, profile);
            });

            return session;
        }

        private void ExecuteSendWorker(TransferSession session, PerformanceProfile profile)
        {
            bool success = false;
            string error = null;
            DateTime start = DateTime.UtcNow;

            try
            {
                ConnectionManager connMgr = new ConnectionManager();
                TcpConnection conn = connMgr.ConnectWithRetry(session.Item.RemoteIpAddress, session.Item.RemotePort, 20000);
                if (conn == null)
                {
                    error = "Could not establish connection to " + session.Item.RemoteIpAddress;
                    CompleteTransfer(session, false, error);
                    return;
                }

                session.Connection = conn;

                // 1. Perform Key Exchange for XPX authenticated encryption session
                using (KeyExchange kx = new KeyExchange())
                {
                    string clientNonceHex, rsaPubKeyXml;
                    kx.ClientInit(out clientNonceHex, out rsaPubKeyXml);

                    string devName = Environment.MachineName;
                    string osName = SystemCapabilities.Current.OperatingSystemName;
                    XpxPacket helloPkt = XpxPacket.CreateHello(1, clientNonceHex, rsaPubKeyXml, devName, osName);
                    conn.SendPacket(helloPkt);

                    XpxPacket helloAckPkt = conn.ReceivePacket();
                    if (helloAckPkt == null || helloAckPkt.Header.PacketType != XpxPacketType.HelloAck)
                    {
                        error = "Key exchange failed: invalid HelloAck from remote peer.";
                        CompleteTransfer(session, false, error);
                        return;
                    }

                    string[] ackParts = helloAckPkt.GetPayloadAsString().Split('\n');
                    string serverNonceHex = ackParts.Length > 0 ? ackParts[0] : "";
                    string encPreMasterBase64 = ackParts.Length > 1 ? ackParts[1] : "";

                    AesSession clientSession = kx.ClientFinishHandshake(serverNonceHex, encPreMasterBase64, helloAckPkt.Header.SessionId);
                    conn.CryptoSession = clientSession;
                }

                // 2. Stream File using FileSender
                FileSender sender = new FileSender();
                success = sender.SendFile(conn, session, profile.AllowCompression,
                    delegate(long transferred, long total)
                    {
                        OnTransferProgress(session.SessionId.ToString(), session.Item.FileName,
                            transferred, total, session.SpeedBytesPerSec, session.EstimatedTimeRemaining);
                    },
                    out error);
            }
            catch (Exception ex)
            {
                success = false;
                error = ex.Message;
                AppLogger.Log("ExecuteSendWorker error: " + ex);
            }
            finally
            {
                if (success)
                {
                    double durationSec = (DateTime.UtcNow - start).TotalSeconds;
                    _networkCapabilities.RecordTransferSample(session.Item.TotalBytes, durationSec);
                }

                CompleteTransfer(session, success, error);
            }
        }

        /// <summary>
        /// Handles an incoming XPX socket connection for file reception.
        /// </summary>
        public void HandleIncomingConnection(Socket socket, string destinationFolder, bool autoAccept)
        {
            if (socket == null) return;

            ThreadPool.QueueUserWorkItem(delegate(object state)
            {
                TcpConnection conn = null;
                TransferSession session = null;
                bool success = false;
                string savedPath = null;
                string error = null;

                try
                {
                    conn = new TcpConnection(socket);

                    // 1. Process Key Exchange Hello packet
                    XpxPacket helloPkt = conn.ReceivePacket();
                    if (helloPkt == null || helloPkt.Header.PacketType != XpxPacketType.Hello)
                    {
                        conn.Close();
                        return;
                    }

                    string[] helloParts = helloPkt.GetPayloadAsString().Split('\n');
                    string clientNonceHex = helloParts.Length > 0 ? helloParts[0] : "";
                    string remoteDevName = helloParts.Length > 1 ? helloParts[1] : "Remote Device";
                    string clientRsaPubKeyXml = helloParts.Length > 3 ? helloParts[3] : "";

                    Guid sessionId = Guid.NewGuid();
                    string serverNonceHex, encPreMasterBase64;
                    AesSession serverSession;

                    KeyExchange.ServerProcessHelloAndDerive(
                        clientNonceHex,
                        clientRsaPubKeyXml,
                        sessionId,
                        out serverNonceHex,
                        out encPreMasterBase64,
                        out serverSession);

                    conn.CryptoSession = serverSession;

                    // Send HelloAck
                    XpxPacket helloAck = XpxPacket.CreateHelloAck(
                        1,
                        sessionId,
                        serverNonceHex,
                        encPreMasterBase64,
                        Environment.MachineName,
                        SystemCapabilities.Current.OperatingSystemName);
                    conn.SendPacket(helloAck);

                    // 2. Receive File via FileReceiver
                    TransferItem item = new TransferItem
                    {
                        RemoteDeviceId = remoteDevName,
                        RemoteDeviceName = remoteDevName,
                        RemoteIpAddress = conn.RemoteIp,
                        RemotePort = conn.RemotePort,
                        Direction = TransferDirection.Download,
                        Status = TransferStatus.InProgress
                    };

                    session = new TransferSession(item, conn, 64 * 1024);
                    lock (_lock)
                    {
                        _activeTransfers.Add(session);
                    }
                    OnTransferStarted(session);

                    FileReceiver receiver = new FileReceiver();
                    success = receiver.ReceiveFile(
                        conn,
                        destinationFolder,
                        autoAccept,
                        delegate(long received, long total)
                        {
                            session.UpdateProgress(received);
                            OnTransferProgress(session.SessionId.ToString(), item.FileName ?? "Incoming",
                                received, total, session.SpeedBytesPerSec, session.EstimatedTimeRemaining);
                        },
                        out savedPath,
                        out error);

                    if (success)
                    {
                        item.FilePath = savedPath;
                    }
                }
                catch (Exception ex)
                {
                    success = false;
                    error = ex.Message;
                    AppLogger.Log("HandleIncomingConnection error: " + ex);
                }
                finally
                {
                    if (session != null)
                    {
                        CompleteTransfer(session, success, error);
                    }
                    else if (conn != null)
                    {
                        conn.Dispose();
                    }
                }
            });
        }

        public void PauseTransfer(string transferId)
        {
            lock (_lock)
            {
                TransferSession s = FindSession(transferId);
                if (s != null) s.Pause();
            }
        }

        public void ResumeTransfer(string transferId)
        {
            lock (_lock)
            {
                TransferSession s = FindSession(transferId);
                if (s != null) s.Resume();
            }
        }

        public void CancelTransfer(string transferId)
        {
            lock (_lock)
            {
                TransferSession s = FindSession(transferId);
                if (s != null) s.Cancel();
            }
        }

        private TransferSession FindSession(string transferId)
        {
            return _activeTransfers.Find(delegate(TransferSession s)
            {
                return string.Equals(s.SessionId.ToString(), transferId, StringComparison.OrdinalIgnoreCase) ||
                       (s.Item != null && string.Equals(s.Item.Id, transferId, StringComparison.OrdinalIgnoreCase));
            });
        }

        private void CompleteTransfer(TransferSession session, bool success, string errorMessage)
        {
            if (session == null) return;

            lock (_lock)
            {
                _activeTransfers.Remove(session);

                if (session.Item != null)
                {
                    session.Item.Status = success ? TransferStatus.Completed : TransferStatus.Failed;
                    session.Item.ErrorMessage = errorMessage;
                    session.Item.CompletedAt = DateTime.UtcNow;

                    for (int i = 0; i < _transferQueue.Count; i++)
                    {
                        if (_transferQueue[i].Id == session.Item.Id)
                        {
                            _transferQueue[i].Status = session.Item.Status;
                            break;
                        }
                    }
                }
            }

            OnTransferCompleted(
                session.SessionId.ToString(),
                success,
                session.Item != null ? session.Item.FilePath : "",
                session.Item != null ? session.Item.TotalBytes : 0,
                errorMessage);

            session.Dispose();
        }

        private void OnTransferStarted(TransferSession session)
        {
            if (TransferStarted != null)
            {
                TransferStarted(this, new TransferManagerEventArgs { Session = session, Item = session.Item });
            }
        }

        private void OnTransferProgress(string id, string name, long transferred, long total, double speed, TimeSpan eta)
        {
            if (TransferProgress != null)
            {
                double pct = total > 0 ? ((double)transferred / (double)total) * 100.0 : 0.0;
                TransferProgress(this, new TransferProgressReportEventArgs
                {
                    TransferId = id,
                    FileName = name,
                    BytesTransferred = transferred,
                    TotalBytes = total,
                    Progress = pct,
                    SpeedBytesPerSec = speed,
                    EstimatedTimeRemaining = eta
                });
            }
        }

        private void OnTransferCompleted(string id, bool success, string path, long total, string err)
        {
            if (TransferCompleted != null)
            {
                TransferCompleted(this, new TransferCompleteReportEventArgs
                {
                    TransferId = id,
                    Success = success,
                    FilePath = path,
                    TotalBytes = total,
                    ErrorMessage = err
                });
            }
        }
    }
}

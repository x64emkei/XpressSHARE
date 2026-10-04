using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using XpressShare.Core;
using XpressShare.Models;
using XpressShare.Network;

namespace XpressShare.Services
{
    public class TransferManager
    {
        private readonly List<TransferSession> _activeTransfers = new List<TransferSession>();
        private readonly List<TransferItem> _transferQueue = new List<TransferItem>();
        private readonly Dictionary<Guid, TransferSession> _pendingApprovals = new Dictionary<Guid, TransferSession>();
        private readonly object _lockObj = new object();

        private readonly PersistentQueueService _queueService;
        private readonly TransferHistoryService _historyService;

        public event EventHandler<TransferProgressEventArgs> TransferProgress;
        public event EventHandler<TransferCompleteEventArgs> TransferCompleted;
        public event EventHandler<TransferSessionEventArgs> TransferRequested;

        public TransferManager()
        {
            _queueService = new PersistentQueueService();
            _historyService = new TransferHistoryService();
            LoadQueueFromDisk();
        }

        public void EnqueueTransfer(TransferItem item)
        {
            if (item == null)
                return;

            lock (_lockObj)
            {
                item.Status = TransferStatus.Pending;
                _transferQueue.Add(item);
                SaveQueueToDisk();
            }

            AppLogger.Log("Transfer queued: " + item.FilePath);
        }

        public List<TransferItem> GetPendingTransfers()
        {
            lock (_lockObj)
            {
                return new List<TransferItem>(_transferQueue);
            }
        }

        public List<TransferSession> GetActiveTransfers()
        {
            lock (_lockObj)
            {
                return new List<TransferSession>(_activeTransfers);
            }
        }

        public List<TransferSession> GetPendingApprovals()
        {
            lock (_lockObj)
            {
                return new List<TransferSession>(_pendingApprovals.Values);
            }
        }

        public void RegisterPendingApproval(TransferSession session)
        {
            if (session == null)
                return;

            lock (_lockObj)
            {
                session.State = TransferSessionState.Pending;
                _pendingApprovals[session.SessionId] = session;
            }

            AppLogger.Log("Incoming transfer registered for approval: " + session.FileName + " from " + session.RemoteDeviceName);

            OnTransferRequested(new TransferSessionEventArgs { Session = session });
        }

        public bool ApproveTransfer(string sessionIdStr)
        {
            try
            {
                Guid id = new Guid(sessionIdStr);
                return ApproveTransfer(id);
            }
            catch
            {
                return false;
            }
        }

        public bool ApproveTransfer(Guid sessionId)
        {
            TransferSession session = null;
            lock (_lockObj)
            {
                if (!_pendingApprovals.TryGetValue(sessionId, out session))
                    return false;

                _pendingApprovals.Remove(sessionId);
                session.State = TransferSessionState.InProgress;
                session.StartTime = DateTime.UtcNow;
                _activeTransfers.Add(session);
            }

            AppLogger.Log("Transfer approved: " + session.FileName);

            // Execute receiving on ThreadPool
            ThreadPool.QueueUserWorkItem(delegate(object state)
            {
                ExecuteReceive(session);
            });

            return true;
        }

        public bool RejectTransfer(string sessionIdStr)
        {
            try
            {
                Guid id = new Guid(sessionIdStr);
                return RejectTransfer(id);
            }
            catch
            {
                return false;
            }
        }

        public bool RejectTransfer(Guid sessionId)
        {
            TransferSession session = null;
            lock (_lockObj)
            {
                if (!_pendingApprovals.TryGetValue(sessionId, out session))
                    return false;

                _pendingApprovals.Remove(sessionId);
                session.State = TransferSessionState.Rejected;
            }

            AppLogger.Log("Transfer rejected: " + session.FileName);

            // Notify sender of rejection and close socket on ThreadPool
            ThreadPool.QueueUserWorkItem(delegate(object state)
            {
                try
                {
                    if (session.Socket != null && session.Socket.Connected)
                    {
                        NetworkStream stream = session.Socket.GetStream();
                        ProtocolMessage rejectMsg = new ProtocolMessage
                        {
                            Type = ProtocolMessageType.TransferReject,
                            Payload = "Rejected by user"
                        };
                        TransferProtocolHandler.SendMessage(stream, rejectMsg);
                    }
                }
                catch (Exception ex)
                {
                    AppLogger.Log("Error sending rejection: " + ex.Message);
                }
                finally
                {
                    session.Dispose();
                }
            });

            return true;
        }

        private void ExecuteReceive(TransferSession session)
        {
            bool success = false;
            string targetFolder = AppSettings.Instance.SelectedDownloadFolder;
            if (string.IsNullOrEmpty(targetFolder))
            {
                string userProfile = Environment.GetEnvironmentVariable("USERPROFILE");
                targetFolder = !string.IsNullOrEmpty(userProfile) ? Path.Combine(userProfile, "Downloads") : Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            }

            try
            {
                if (session.Socket == null || !session.Socket.Connected)
                {
                    AppLogger.Log("Socket not connected for approved session: " + session.SessionId);
                    CompleteTransfer(session.SessionId, false);
                    return;
                }

                NetworkStream stream = session.Socket.GetStream();

                // Send accept message
                ProtocolMessage acceptMsg = new ProtocolMessage
                {
                    Type = ProtocolMessageType.TransferAccept,
                    Payload = "OK"
                };
                if (!TransferProtocolHandler.SendMessage(stream, acceptMsg))
                {
                    CompleteTransfer(session.SessionId, false);
                    return;
                }

                // Receive file payload
                success = TransferProtocolHandler.ReceiveFilePayload(
                    stream,
                    targetFolder,
                    session.FileName,
                    session.TotalBytes,
                    delegate(long bytesTransferred)
                    {
                        UpdateProgress(session.SessionId, bytesTransferred);
                    });
            }
            catch (Exception ex)
            {
                AppLogger.Log("ExecuteReceive error: " + ex.Message);
                success = false;
            }
            finally
            {
                string downloadedPath = Path.Combine(targetFolder, session.FileName);
                if (success)
                {
                    session.FilePath = downloadedPath;
                }

                // Record transfer in history
                _historyService.RecordTransfer(
                    session.RemoteDeviceId,
                    session.RemoteDeviceName,
                    downloadedPath,
                    session.TotalBytes,
                    success,
                    false);

                CompleteTransfer(session.SessionId, success);
            }
        }

        public TransferSession StartSendFile(string remoteDeviceId, string remoteDeviceName, string remoteIp, int remotePort, string filePath, DeviceIdentity localIdentity, Action<TransferSession> onStarted)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                return null;

            FileInfo info = new FileInfo(filePath);
            TransferSession session = new TransferSession
            {
                RemoteDeviceId = remoteDeviceId,
                RemoteDeviceName = remoteDeviceName,
                RemoteIpAddress = remoteIp,
                RemotePort = remotePort,
                FilePath = filePath,
                TotalBytes = info.Length,
                IsUpload = true,
                State = TransferSessionState.InProgress
            };

            lock (_lockObj)
            {
                _activeTransfers.Add(session);
            }

            if (onStarted != null)
            {
                onStarted(session);
            }

            ThreadPool.QueueUserWorkItem(delegate(object state)
            {
                ExecuteSend(session, localIdentity);
            });

            return session;
        }

        private void ExecuteSend(TransferSession session, DeviceIdentity localIdentity)
        {
            bool success = false;
            TcpClient client = null;

            try
            {
                client = new TcpClient();
                client.SendTimeout = 60000;
                client.ReceiveTimeout = 60000;
                client.Connect(session.RemoteIpAddress, session.RemotePort);

                session.Socket = client;

                string localId = localIdentity != null ? localIdentity.DeviceId : "";
                string localName = localIdentity != null ? localIdentity.DeviceName : "";

                success = TransferProtocolHandler.SendFile(
                    client,
                    session.FilePath,
                    localId,
                    localName,
                    delegate(long bytesSent)
                    {
                        UpdateProgress(session.SessionId, bytesSent);
                    });
            }
            catch (Exception ex)
            {
                AppLogger.Log("ExecuteSend error: " + ex.Message);
                success = false;
            }
            finally
            {
                // Record in history
                _historyService.RecordTransfer(
                    session.RemoteDeviceId,
                    session.RemoteDeviceName,
                    session.FilePath,
                    session.TotalBytes,
                    success,
                    true);

                CompleteTransfer(session.SessionId, success);
            }
        }

        public void UpdateProgress(Guid sessionId, long bytesTransferred)
        {
            UpdateProgress(sessionId.ToString(), bytesTransferred);
        }

        public void UpdateProgress(string sessionIdStr, long bytesTransferred)
        {
            lock (_lockObj)
            {
                TransferSession session = _activeTransfers.Find(delegate(TransferSession s)
                {
                    return string.Equals(s.SessionId.ToString(), sessionIdStr, StringComparison.OrdinalIgnoreCase);
                });

                if (session != null)
                {
                    session.TransferredBytes = bytesTransferred;

                    OnTransferProgress(new TransferProgressEventArgs
                    {
                        SessionId = session.SessionId.ToString(),
                        FileName = session.FileName,
                        Progress = session.Progress,
                        BytesTransferred = bytesTransferred,
                        TotalBytes = session.TotalBytes,
                        Speed = session.Speed,
                        EstimatedTimeRemaining = session.EstimatedTimeRemaining
                    });
                }
            }
        }

        public void PauseTransfer(string sessionIdStr)
        {
            lock (_lockObj)
            {
                TransferSession session = _activeTransfers.Find(delegate(TransferSession s)
                {
                    return string.Equals(s.SessionId.ToString(), sessionIdStr, StringComparison.OrdinalIgnoreCase);
                });

                if (session != null)
                {
                    session.State = TransferSessionState.Paused;
                }
            }
        }

        public void ResumeTransfer(string sessionIdStr)
        {
            lock (_lockObj)
            {
                TransferSession session = _activeTransfers.Find(delegate(TransferSession s)
                {
                    return string.Equals(s.SessionId.ToString(), sessionIdStr, StringComparison.OrdinalIgnoreCase);
                });

                if (session != null && session.State == TransferSessionState.Paused)
                {
                    session.State = TransferSessionState.InProgress;
                }
            }
        }

        public void CompleteTransfer(Guid sessionId, bool success)
        {
            CompleteTransfer(sessionId.ToString(), success);
        }

        public void CompleteTransfer(string sessionIdStr, bool success)
        {
            lock (_lockObj)
            {
                TransferSession session = _activeTransfers.Find(delegate(TransferSession s)
                {
                    return string.Equals(s.SessionId.ToString(), sessionIdStr, StringComparison.OrdinalIgnoreCase);
                });

                if (session != null)
                {
                    session.State = success ? TransferSessionState.Completed : TransferSessionState.Failed;
                    _activeTransfers.Remove(session);

                    OnTransferCompleted(new TransferCompleteEventArgs
                    {
                        SessionId = session.SessionId.ToString(),
                        Success = success,
                        FilePath = session.FilePath,
                        TotalBytes = session.TotalBytes
                    });

                    session.Dispose();
                }

                // If any item in queue matches, mark completed/failed
                for (int i = 0; i < _transferQueue.Count; i++)
                {
                    if (_transferQueue[i].Id == sessionIdStr || _transferQueue[i].FilePath == (session != null ? session.FilePath : null))
                    {
                        _transferQueue[i].Status = success ? TransferStatus.Completed : TransferStatus.Failed;
                        break;
                    }
                }
                SaveQueueToDisk();
            }
        }

        public void CancelTransfer(string sessionIdStr)
        {
            lock (_lockObj)
            {
                TransferSession session = _activeTransfers.Find(delegate(TransferSession s)
                {
                    return string.Equals(s.SessionId.ToString(), sessionIdStr, StringComparison.OrdinalIgnoreCase);
                });

                if (session != null)
                {
                    session.State = TransferSessionState.Cancelled;
                    _activeTransfers.Remove(session);
                    session.Dispose();
                }
            }
        }

        private void LoadQueueFromDisk()
        {
            try
            {
                List<TransferItem> loaded = _queueService.LoadQueue();
                if (loaded != null)
                {
                    lock (_lockObj)
                    {
                        _transferQueue.Clear();
                        _transferQueue.AddRange(loaded);
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogger.Log("LoadQueueFromDisk error: " + ex.Message);
            }
        }

        private void SaveQueueToDisk()
        {
            try
            {
                _queueService.SaveQueue(_transferQueue);
            }
            catch (Exception ex)
            {
                AppLogger.Log("SaveQueueToDisk error: " + ex.Message);
            }
        }

        private void OnTransferProgress(TransferProgressEventArgs e)
        {
            if (TransferProgress != null)
            {
                TransferProgress(this, e);
            }
        }

        private void OnTransferCompleted(TransferCompleteEventArgs e)
        {
            if (TransferCompleted != null)
            {
                TransferCompleted(this, e);
            }
        }

        private void OnTransferRequested(TransferSessionEventArgs e)
        {
            if (TransferRequested != null)
            {
                TransferRequested(this, e);
            }
        }
    }

    public class TransferSessionEventArgs : EventArgs
    {
        public TransferSession Session { get; set; }
    }

    public class TransferProgressEventArgs : EventArgs
    {
        public string SessionId { get; set; }
        public string FileName { get; set; }
        public double Progress { get; set; }
        public long BytesTransferred { get; set; }
        public long TotalBytes { get; set; }
        public double Speed { get; set; }
        public TimeSpan EstimatedTimeRemaining { get; set; }
    }

    public class TransferCompleteEventArgs : EventArgs
    {
        public string SessionId { get; set; }
        public bool Success { get; set; }
        public string FilePath { get; set; }
        public long TotalBytes { get; set; }
    }
}

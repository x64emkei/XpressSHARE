using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using XpressShare.Core;
using XpressShare.Models;
using XpressShare.Network;

namespace XpressShare.Services
{
    public class TransferListenerService
    {
        private TcpListener _listener;
        private Thread _listenerThread;
        private volatile bool _isRunning;
        private readonly object _lockObj = new object();
        private readonly TransferManager _transferManager;

        public event EventHandler<TransferRequestEventArgs> TransferRequested;

        public TransferListenerService()
            : this(null)
        {
        }

        public TransferListenerService(TransferManager transferManager)
        {
            _transferManager = transferManager;
        }

        public void Start()
        {
            lock (_lockObj)
            {
                if (_isRunning)
                    return;

                _isRunning = true;

                int port = AppSettings.Instance.TransferPort;
                if (port <= 0)
                    port = 15001;

                try
                {
                    _listener = new TcpListener(IPAddress.Any, port);
                    _listener.Start();

                    _listenerThread = new Thread(ListenerThread);
                    _listenerThread.IsBackground = true;
                    _listenerThread.Start();

                    AppLogger.Log("TransferListenerService started on port " + port);
                }
                catch (Exception ex)
                {
                    AppLogger.Log("TransferListenerService.Start error: " + ex.Message);
                    _isRunning = false;
                }
            }
        }

        public void Stop()
        {
            lock (_lockObj)
            {
                _isRunning = false;

                if (_listener != null)
                {
                    try { _listener.Stop(); }
                    catch { }
                    _listener = null;
                }

                AppLogger.Log("TransferListenerService stopped");
            }
        }

        private void ListenerThread()
        {
            try
            {
                while (_isRunning)
                {
                    try
                    {
                        TcpClient client = _listener.AcceptTcpClient();

                        // Handle client connection in a thread pool thread
                        ThreadPool.QueueUserWorkItem(HandleClient, client);
                    }
                    catch (SocketException)
                    {
                        // Normal when stopping
                        if (!_isRunning)
                            break;
                    }
                    catch (Exception ex)
                    {
                        AppLogger.Log("TransferListenerService accept error: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogger.Log("ListenerThread error: " + ex.Message);
            }
        }

        private void HandleClient(object state)
        {
            TcpClient client = state as TcpClient;
            if (client == null)
                return;

            try
            {
                NetworkStream stream = client.GetStream();
                stream.ReadTimeout = 60000;
                stream.WriteTimeout = 60000;

                // Read length-prefixed ProtocolMessage
                ProtocolMessage msg = TransferProtocolHandler.ReadMessage(stream);
                if (msg == null || msg.Type != ProtocolMessageType.TransferStart)
                {
                    AppLogger.Log("HandleClient: Invalid or non-TransferStart message received.");
                    client.Close();
                    return;
                }

                string[] parts = (msg.Payload ?? "").Split(new char[] { '|' }, StringSplitOptions.None);
                string fileName = parts.Length > 0 ? parts[0] : "unknown_file";
                long fileSize = 0;
                if (parts.Length > 1)
                {
                    long.TryParse(parts[1], out fileSize);
                }

                string remoteIp = "127.0.0.1";
                int remotePort = 0;
                try
                {
                    IPEndPoint endpoint = client.Client.RemoteEndPoint as IPEndPoint;
                    if (endpoint != null)
                    {
                        remoteIp = endpoint.Address.ToString();
                        remotePort = endpoint.Port;
                    }
                }
                catch
                {
                }

                TransferSession session = new TransferSession
                {
                    RemoteDeviceId = msg.SenderId ?? string.Empty,
                    RemoteDeviceName = msg.SenderName ?? string.Empty,
                    RemoteIpAddress = remoteIp,
                    RemotePort = remotePort,
                    FilePath = fileName,
                    TotalBytes = fileSize,
                    IsUpload = false,
                    Socket = client
                };

                // Register with TransferManager if available
                TransferManager tm = _transferManager ?? ServiceRegistry.Resolve<TransferManager>("TransferManager");
                if (tm != null)
                {
                    tm.RegisterPendingApproval(session);
                }

                OnTransferRequested(new TransferRequestEventArgs
                {
                    Session = session,
                    RemoteDeviceId = session.RemoteDeviceId,
                    RemoteDeviceName = session.RemoteDeviceName,
                    FileName = session.FileName,
                    FileSize = session.TotalBytes,
                    Payload = msg.Payload,
                    Client = client
                });
            }
            catch (Exception ex)
            {
                AppLogger.Log("HandleClient error: " + ex.Message);
                try { client.Close(); }
                catch { }
            }
        }

        private void OnTransferRequested(TransferRequestEventArgs e)
        {
            if (TransferRequested != null)
            {
                TransferRequested(this, e);
            }
        }
    }

    public class TransferRequestEventArgs : EventArgs
    {
        public TransferSession Session { get; set; }
        public string RemoteDeviceId { get; set; }
        public string RemoteDeviceName { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string Payload { get; set; }
        public TcpClient Client { get; set; }
    }
}

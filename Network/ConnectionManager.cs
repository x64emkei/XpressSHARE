using System;
using System.Threading;
using XpressShare.Core;

namespace XpressShare.Network
{
    public enum PeerConnectionStatus
    {
        Offline,
        Connecting,
        Online,
        ConnectionLost,
        Reconnecting
    }

    public class ConnectionStatusEventArgs : EventArgs
    {
        public string RemoteIp { get; set; }
        public int RemotePort { get; set; }
        public PeerConnectionStatus Status { get; set; }
        public string StatusMessage { get; set; }
    }

    /// <summary>
    /// Manages connections to remote peers with controlled reconnect backoff.
    /// Prevents tight loops and ensures low-power systems are not overloaded.
    /// </summary>
    public class ConnectionManager
    {
        public event EventHandler<ConnectionStatusEventArgs> StatusChanged;

        private readonly int _maxRetries;
        private readonly int[] _backoffDelaysMs = new int[] { 1000, 2500, 5000, 10000 };

        public ConnectionManager()
            : this(4)
        {
        }

        public ConnectionManager(int maxRetries)
        {
            _maxRetries = Math.Min(maxRetries, _backoffDelaysMs.Length);
        }

        /// <summary>
        /// Attempts to establish a connection with limited exponential backoff.
        /// </summary>
        public TcpConnection ConnectWithRetry(string host, int port, int timeoutMs)
        {
            int attempt = 0;
            TcpConnection conn = null;

            while (attempt <= _maxRetries)
            {
                attempt++;
                NotifyStatus(host, port, attempt == 1 ? PeerConnectionStatus.Connecting : PeerConnectionStatus.Reconnecting,
                    string.Format("Connecting to {0}:{1} (Attempt {2}/{3})...", host, port, attempt, _maxRetries + 1));

                try
                {
                    conn = new TcpConnection();
                    conn.Connect(host, port, timeoutMs);
                    NotifyStatus(host, port, PeerConnectionStatus.Online, "Connected to " + host + ":" + port);
                    return conn;
                }
                catch (Exception ex)
                {
                    if (conn != null)
                    {
                        conn.Dispose();
                        conn = null;
                    }

                    AppLogger.Log(string.Format("Connect attempt {0} failed to {1}:{2}: {3}", attempt, host, port, ex.Message));

                    if (attempt > _maxRetries)
                    {
                        NotifyStatus(host, port, PeerConnectionStatus.Offline, "Failed to connect after multiple retries.");
                        break;
                    }

                    int delay = _backoffDelaysMs[Math.Min(attempt - 1, _backoffDelaysMs.Length - 1)];
                    NotifyStatus(host, port, PeerConnectionStatus.ConnectionLost,
                        string.Format("Connection failed. Waiting {0}ms before retry...", delay));
                    Thread.Sleep(delay);
                }
            }

            return null;
        }

        private void NotifyStatus(string ip, int port, PeerConnectionStatus status, string message)
        {
            if (StatusChanged != null)
            {
                StatusChanged(this, new ConnectionStatusEventArgs
                {
                    RemoteIp = ip,
                    RemotePort = port,
                    Status = status,
                    StatusMessage = message
                });
            }
        }
    }
}

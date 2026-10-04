using System;
using System.Threading;
using XpressShare.Core;
using XpressShare.Protocol;

namespace XpressShare.Network
{
    /// <summary>
    /// Lightweight heartbeat manager to detect half-open TCP sockets and network drops.
    /// Operates with low memory allocation and minimal CPU wake-ups to protect legacy machines.
    /// </summary>
    public class HeartbeatManager : IDisposable
    {
        private readonly TcpConnection _connection;
        private readonly int _intervalMs;
        private readonly int _timeoutMs;
        private Thread _heartbeatThread;
        private volatile bool _isRunning;
        private DateTime _lastAckReceived;
        private readonly object _lock = new object();

        public event EventHandler HeartbeatFailed;

        public HeartbeatManager(TcpConnection connection, int intervalMs, int timeoutMs)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            _connection = connection;
            _intervalMs = intervalMs > 0 ? intervalMs : XpxProtocolConstants.DefaultHeartbeatIntervalMs;
            _timeoutMs = timeoutMs > 0 ? timeoutMs : XpxProtocolConstants.HeartbeatTimeoutMs;
            _lastAckReceived = DateTime.UtcNow;
        }

        public void Start()
        {
            lock (_lock)
            {
                if (_isRunning) return;
                _isRunning = true;
                _lastAckReceived = DateTime.UtcNow;

                _heartbeatThread = new Thread(HeartbeatLoop);
                _heartbeatThread.IsBackground = true;
                _heartbeatThread.Name = "XPX-Heartbeat-Worker";
                _heartbeatThread.Start();
            }
        }

        public void Stop()
        {
            lock (_lock)
            {
                _isRunning = false;
            }
        }

        public void NotifyAckReceived()
        {
            _lastAckReceived = DateTime.UtcNow;
        }

        private void HeartbeatLoop()
        {
            try
            {
                while (_isRunning && _connection.IsConnected)
                {
                    Thread.Sleep(_intervalMs);
                    if (!_isRunning || !_connection.IsConnected) break;

                    // Check timeout
                    TimeSpan elapsed = DateTime.UtcNow - _lastAckReceived;
                    if (elapsed.TotalMilliseconds > _timeoutMs)
                    {
                        AppLogger.Log("Heartbeat timeout! Peer unresponsive for " + elapsed.TotalSeconds + "s.");
                        OnHeartbeatFailed();
                        break;
                    }

                    // Send lightweight heartbeat packet
                    try
                    {
                        XpxPacket pkt = XpxPacket.CreateHeartbeat(0, Guid.Empty);
                        _connection.SendPacket(pkt);
                    }
                    catch (Exception ex)
                    {
                        AppLogger.Log("Failed to send heartbeat packet: " + ex.Message);
                        OnHeartbeatFailed();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogger.Log("HeartbeatLoop error: " + ex.Message);
            }
        }

        private void OnHeartbeatFailed()
        {
            Stop();
            if (HeartbeatFailed != null)
            {
                HeartbeatFailed(this, EventArgs.Empty);
            }
        }

        public void Dispose()
        {
            Stop();
        }
    }
}

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using XpressShare.Core;
using XpressShare.Models;
using XpressShare.Network;

namespace XpressShare.Services
{
    public class LanDiscoveryService
    {
        private const int DefaultBroadcastPort = 15000;
        private const int BroadcastIntervalMs = 5000; // 5 seconds

        private UdpClient _broadcastClient;
        private UdpClient _listenerClient;
        private Thread _broadcastThread;
        private Thread _listenerThread;
        private volatile bool _isRunning;
        private DeviceIdentity _localIdentity;
        private readonly object _lockObj = new object();

        public event EventHandler<DeviceDiscoveredEventArgs> DeviceDiscovered;

        public LanDiscoveryService()
        {
        }

        public void Start(DeviceIdentity identity)
        {
            lock (_lockObj)
            {
                if (_isRunning)
                    return;

                _localIdentity = identity;
                _isRunning = true;

                try
                {
                    // Start broadcast thread (sends our identity)
                    _broadcastThread = new Thread(BroadcastThread);
                    _broadcastThread.IsBackground = true;
                    _broadcastThread.Start();

                    // Start listener thread (listens for peer identities)
                    _listenerThread = new Thread(ListenerThread);
                    _listenerThread.IsBackground = true;
                    _listenerThread.Start();

                    AppLogger.Log("LanDiscoveryService started on port " + DefaultBroadcastPort);
                }
                catch (Exception ex)
                {
                    AppLogger.Log("LanDiscoveryService.Start error: " + ex.Message);
                    _isRunning = false;
                }
            }
        }

        public void Stop()
        {
            lock (_lockObj)
            {
                _isRunning = false;

                if (_broadcastClient != null)
                {
                    try { _broadcastClient.Close(); }
                    catch { }
                    _broadcastClient = null;
                }

                if (_listenerClient != null)
                {
                    try { _listenerClient.Close(); }
                    catch { }
                    _listenerClient = null;
                }

                AppLogger.Log("LanDiscoveryService stopped");
            }
        }

        private void BroadcastThread()
        {
            try
            {
                _broadcastClient = new UdpClient(AddressFamily.InterNetwork);
                _broadcastClient.EnableBroadcast = true;

                while (_isRunning)
                {
                    try
                    {
                        // Create identity message
                        var msg = new ProtocolMessage
                        {
                            Type = ProtocolMessageType.Identity,
                            SenderId = _localIdentity.DeviceId,
                            SenderName = _localIdentity.DeviceName,
                            SenderIp = _localIdentity.LocalIpAddress
                        };

                        byte[] data = msg.Serialize();

                        // Broadcast on all network interfaces
                        IPEndPoint broadcastEndpoint = new IPEndPoint(IPAddress.Broadcast, DefaultBroadcastPort);
                        _broadcastClient.Send(data, data.Length, broadcastEndpoint);

                        Thread.Sleep(BroadcastIntervalMs);
                    }
                    catch (Exception ex)
                    {
                        AppLogger.Log("BroadcastThread send error: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogger.Log("BroadcastThread error: " + ex.Message);
            }
        }

        private void ListenerThread()
        {
            try
            {
                _listenerClient = new UdpClient(DefaultBroadcastPort);
                _listenerClient.EnableBroadcast = true;

                while (_isRunning)
                {
                    try
                    {
                        IPEndPoint remoteEndpoint = new IPEndPoint(IPAddress.Any, 0);
                        byte[] data = _listenerClient.Receive(ref remoteEndpoint);

                        ProtocolMessage msg = ProtocolMessage.Deserialize(data);
                        if (msg != null && msg.Type == ProtocolMessageType.Identity)
                        {
                            // Ignore our own broadcasts
                            if (msg.SenderId == _localIdentity.DeviceId)
                                continue;

                            OnDeviceDiscovered(new DeviceDiscoveredEventArgs
                            {
                                DeviceId = msg.SenderId,
                                DeviceName = msg.SenderName,
                                IpAddress = msg.SenderIp ?? remoteEndpoint.Address.ToString()
                            });
                        }
                    }
                    catch (SocketException)
                    {
                        // Normal when stopping
                        if (!_isRunning)
                            break;
                    }
                    catch (Exception ex)
                    {
                        AppLogger.Log("ListenerThread error: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogger.Log("ListenerThread initialization error: " + ex.Message);
            }
        }

        private void OnDeviceDiscovered(DeviceDiscoveredEventArgs e)
        {
            if (DeviceDiscovered != null)
            {
                DeviceDiscovered(this, e);
            }
        }
    }

    public class DeviceDiscoveredEventArgs : EventArgs
    {
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string IpAddress { get; set; }
    }
}


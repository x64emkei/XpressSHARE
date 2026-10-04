using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using XpressShare.Core;
using XpressShare.Devices;
using XpressShare.Protocol;

namespace XpressShare.Network
{
    public class DiscoveredPeerEventArgs : EventArgs
    {
        public DeviceInfo Peer { get; set; }
    }

    /// <summary>
    /// Multi-homed UDP LAN discovery service supporting both Ethernet and Wi-Fi networks.
    /// Operates efficiently without consuming unnecessary CPU or network bandwidth on legacy hardware.
    /// </summary>
    public class NetworkDiscovery : IDisposable
    {
        private readonly int _discoveryPort;
        private UdpClient _broadcastClient;
        private UdpClient _listenerClient;
        private Thread _broadcastThread;
        private Thread _listenerThread;
        private volatile bool _isRunning;
        private readonly object _lock = new object();

        public DeviceInfo LocalDevice { get; set; }
        public event EventHandler<DiscoveredPeerEventArgs> PeerDiscovered;

        public NetworkDiscovery()
            : this(XpxProtocolConstants.DefaultDiscoveryPort)
        {
        }

        public NetworkDiscovery(int discoveryPort)
        {
            _discoveryPort = discoveryPort;
        }

        public void Start(DeviceInfo localDevice)
        {
            lock (_lock)
            {
                if (_isRunning) return;

                LocalDevice = localDevice;
                _isRunning = true;

                try
                {
                    _broadcastThread = new Thread(BroadcastWorker);
                    _broadcastThread.IsBackground = true;
                    _broadcastThread.Name = "XPX-Discovery-Broadcast";
                    _broadcastThread.Start();

                    _listenerThread = new Thread(ListenerWorker);
                    _listenerThread.IsBackground = true;
                    _listenerThread.Name = "XPX-Discovery-Listener";
                    _listenerThread.Start();

                    AppLogger.Log("NetworkDiscovery started on port " + _discoveryPort);
                }
                catch (Exception ex)
                {
                    AppLogger.Log("NetworkDiscovery.Start error: " + ex.Message);
                    _isRunning = false;
                }
            }
        }

        public void Stop()
        {
            lock (_lock)
            {
                if (!_isRunning) return;
                _isRunning = false;

                if (_broadcastClient != null)
                {
                    try { _broadcastClient.Close(); } catch { }
                    _broadcastClient = null;
                }

                if (_listenerClient != null)
                {
                    try { _listenerClient.Close(); } catch { }
                    _listenerClient = null;
                }

                AppLogger.Log("NetworkDiscovery stopped.");
            }
        }

        private void BroadcastWorker()
        {
            try
            {
                _broadcastClient = new UdpClient(AddressFamily.InterNetwork);
                _broadcastClient.EnableBroadcast = true;

                while (_isRunning)
                {
                    try
                    {
                        if (LocalDevice != null)
                        {
                            byte[] beacon = FormatBeaconPayload(LocalDevice);

                            // 1. Send general broadcast
                            IPEndPoint generalBroadcast = new IPEndPoint(IPAddress.Broadcast, _discoveryPort);
                            _broadcastClient.Send(beacon, beacon.Length, generalBroadcast);

                            // 2. Multi-homed interface broadcast (Ethernet + Wi-Fi)
                            List<IPAddress> broadcasts = GetSubnetBroadcastAddresses();
                            foreach (IPAddress bcast in broadcasts)
                            {
                                try
                                {
                                    _broadcastClient.Send(beacon, beacon.Length, new IPEndPoint(bcast, _discoveryPort));
                                }
                                catch { }
                            }
                        }

                        // Sleep interval: 8 seconds (preserves battery & CPU on old laptops)
                        for (int i = 0; i < 80 && _isRunning; i++)
                        {
                            Thread.Sleep(100);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (!_isRunning) break;
                        AppLogger.Log("BroadcastWorker error: " + ex.Message);
                        Thread.Sleep(2000);
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogger.Log("BroadcastWorker fatal: " + ex.Message);
            }
        }

        private void ListenerWorker()
        {
            try
            {
                _listenerClient = new UdpClient();
                _listenerClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                _listenerClient.Client.Bind(new IPEndPoint(IPAddress.Any, _discoveryPort));

                while (_isRunning)
                {
                    try
                    {
                        IPEndPoint remoteEp = new IPEndPoint(IPAddress.Any, 0);
                        byte[] data = _listenerClient.Receive(ref remoteEp);

                        DeviceInfo peer = ParseBeaconPayload(data, remoteEp.Address.ToString());
                        if (peer != null)
                        {
                            // Filter out self-broadcast
                            if (LocalDevice != null && string.Equals(peer.DeviceId, LocalDevice.DeviceId, StringComparison.OrdinalIgnoreCase))
                                continue;

                            OnPeerDiscovered(peer);
                        }
                    }
                    catch (SocketException)
                    {
                        if (!_isRunning) break;
                    }
                    catch (Exception ex)
                    {
                        if (!_isRunning) break;
                        AppLogger.Log("ListenerWorker receive error: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogger.Log("ListenerWorker fatal: " + ex.Message);
            }
        }

        private static byte[] FormatBeaconPayload(DeviceInfo dev)
        {
            // XPX-DISCOVERY|Version|DeviceId|DeviceName|Hostname|IpAddress|Port|OsName|ConnType|Caps
            StringBuilder sb = new StringBuilder();
            sb.Append("XPX-DISCOVERY|")
              .Append("1|")
              .Append(dev.DeviceId ?? "").Append("|")
              .Append(dev.DeviceName ?? "").Append("|")
              .Append(dev.Hostname ?? "").Append("|")
              .Append(dev.IpAddress ?? "").Append("|")
              .Append(dev.Port).Append("|")
              .Append(dev.OperatingSystem ?? "").Append("|")
              .Append(dev.ConnectionType ?? "").Append("|")
              .Append(dev.CapabilitiesSummary ?? "");

            return Encoding.UTF8.GetBytes(sb.ToString());
        }

        private static DeviceInfo ParseBeaconPayload(byte[] data, string fallbackIp)
        {
            if (data == null || data.Length == 0) return null;

            string text = Encoding.UTF8.GetString(data);
            if (!text.StartsWith("XPX-DISCOVERY|"))
                return null;

            string[] parts = text.Split('|');
            if (parts.Length < 9)
                return null;

            DeviceInfo dev = new DeviceInfo();
            dev.DeviceId = parts[2];
            dev.DeviceName = parts[3];
            dev.Hostname = parts[4];
            dev.IpAddress = !string.IsNullOrEmpty(parts[5]) ? parts[5] : fallbackIp;
            int port;
            if (int.TryParse(parts[6], out port)) dev.Port = port;
            else dev.Port = XpxProtocolConstants.DefaultTransferPort;
            dev.OperatingSystem = parts[7];
            dev.ConnectionType = parts[8];
            if (parts.Length > 9) dev.CapabilitiesSummary = parts[9];
            dev.IsOnline = true;
            dev.LastSeen = DateTime.UtcNow;

            return dev;
        }

        private static List<IPAddress> GetSubnetBroadcastAddresses()
        {
            List<IPAddress> list = new List<IPAddress>();
            try
            {
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface ni in interfaces)
                {
                    if (ni.OperationalStatus != OperationalStatus.Up || ni.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                        continue;

                    IPInterfaceProperties ipProps = ni.GetIPProperties();
                    foreach (UnicastIPAddressInformation u in ipProps.UnicastAddresses)
                    {
                        if (u.Address.AddressFamily == AddressFamily.InterNetwork && u.IPv4Mask != null)
                        {
                            byte[] ipBytes = u.Address.GetAddressBytes();
                            byte[] maskBytes = u.IPv4Mask.GetAddressBytes();
                            byte[] broadcastBytes = new byte[4];
                            for (int i = 0; i < 4; i++)
                            {
                                broadcastBytes[i] = (byte)(ipBytes[i] | ~maskBytes[i]);
                            }
                            list.Add(new IPAddress(broadcastBytes));
                        }
                    }
                }
            }
            catch { }
            return list;
        }

        private void OnPeerDiscovered(DeviceInfo peer)
        {
            if (PeerDiscovered != null)
            {
                PeerDiscovered(this, new DiscoveredPeerEventArgs { Peer = peer });
            }
        }

        public void Dispose()
        {
            Stop();
        }
    }
}

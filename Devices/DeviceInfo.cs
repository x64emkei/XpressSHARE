using System;

namespace XpressShare.Devices
{
    /// <summary>
    /// Represents device metadata and operational status across the network.
    /// Compatible with Windows XP SP3 through Windows 11.
    /// </summary>
    public class DeviceInfo
    {
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string Hostname { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public string ConnectionType { get; set; } // "Ethernet", "Wi-Fi", "Loopback"
        public string OperatingSystem { get; set; }
        public bool IsOnline { get; set; }
        public bool IsTrusted { get; set; }
        public DateTime LastSeen { get; set; }
        public string CapabilitiesSummary { get; set; }

        public DeviceInfo()
        {
            Port = 15001;
            ConnectionType = "Ethernet";
            IsOnline = true;
            LastSeen = DateTime.UtcNow;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(IpAddress))
            {
                return string.Format("{0} ({1}) - {2}", DeviceName, IpAddress, ConnectionType);
            }
            return DeviceName ?? "Unknown Device";
        }
    }
}

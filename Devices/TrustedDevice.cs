using System;

namespace XpressShare.Devices
{
    /// <summary>
    /// Represents a paired trusted device credential.
    /// Stores secure pairing tokens without saving raw user passwords.
    /// </summary>
    public class TrustedDevice
    {
        public string DeviceId { get; set; }
        public string Name { get; set; }
        public string Hostname { get; set; }
        public string IpAddress { get; set; }
        public string ConnectionType { get; set; }
        public string PairingToken { get; set; }
        public DateTime TrustedSince { get; set; }
        public DateTime LastUsed { get; set; }

        public TrustedDevice()
        {
            TrustedSince = DateTime.UtcNow;
            LastUsed = DateTime.UtcNow;
            ConnectionType = "Ethernet";
        }
    }
}

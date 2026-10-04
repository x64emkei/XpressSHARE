using System;

namespace XpressShare.Models
{
    public class TrustedDevice
    {
        public string DeviceId { get; set; }
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public string ConnectionType { get; set; }
        public string PairingToken { get; set; }
        public DateTime TrustedSince { get; set; }
        public DateTime LastUsed { get; set; }
    }
}

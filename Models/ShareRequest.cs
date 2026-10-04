using System;

namespace XpressShare.Models
{
    public class ShareRequest
    {
        public string FromDeviceId { get; set; }
        public string ToDeviceId { get; set; }
        public string FileName { get; set; }
        public long Size { get; set; }
    }
}

using System;

namespace XpressShare.Models
{
    public class TransferItem
    {
        public string Id { get; set; }
        public string RemoteDeviceId { get; set; }
        public string RemoteDeviceName { get; set; }
        public string RemoteIpAddress { get; set; }
        public int RemotePort { get; set; }
        public string FilePath { get; set; }
        public long TotalBytes { get; set; }
        public long TransferredBytes { get; set; }
        public TransferStatus Status { get; set; }
        public TransferDirection Direction { get; set; }
        public DateTime CreatedTime { get; set; }

        public TransferItem()
        {
            Id = Guid.NewGuid().ToString("N");
            Status = TransferStatus.Pending;
            Direction = TransferDirection.Upload;
            CreatedTime = DateTime.UtcNow;
            RemoteDeviceId = string.Empty;
            RemoteDeviceName = string.Empty;
            RemoteIpAddress = string.Empty;
            FilePath = string.Empty;
        }
    }
}

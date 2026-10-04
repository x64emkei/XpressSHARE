using System;
using System.IO;

namespace XpressShare.Transfers
{
    public enum TransferStatus
    {
        Pending,
        Negotiating,
        InProgress,
        Paused,
        Completed,
        Failed,
        Cancelled
    }

    public enum TransferDirection
    {
        Upload,
        Download
    }

    /// <summary>
    /// Represents a queued, active, or completed file transfer item.
    /// </summary>
    public class TransferItem
    {
        public string Id { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public long TotalBytes { get; set; }
        public long TransferredBytes { get; set; }
        public TransferStatus Status { get; set; }
        public TransferDirection Direction { get; set; }
        public string RemoteDeviceId { get; set; }
        public string RemoteDeviceName { get; set; }
        public string RemoteIpAddress { get; set; }
        public int RemotePort { get; set; }
        public string Sha256Hash { get; set; }
        public string ErrorMessage { get; set; }
        public double SpeedBytesPerSec { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CompletedAt { get; set; }

        public double ProgressPercentage
        {
            get
            {
                if (TotalBytes <= 0) return 0.0;
                double pct = ((double)TransferredBytes / (double)TotalBytes) * 100.0;
                return Math.Min(100.0, Math.Max(0.0, pct));
            }
        }

        public TransferItem()
        {
            Id = Guid.NewGuid().ToString();
            Status = TransferStatus.Pending;
            Direction = TransferDirection.Upload;
            CreatedAt = DateTime.UtcNow;
        }

        public TransferItem(string filePath, string remoteDeviceId, string remoteDeviceName, string remoteIp, int remotePort)
            : this()
        {
            FilePath = filePath;
            FileName = Path.GetFileName(filePath);
            RemoteDeviceId = remoteDeviceId;
            RemoteDeviceName = remoteDeviceName;
            RemoteIpAddress = remoteIp;
            RemotePort = remotePort;

            if (File.Exists(filePath))
            {
                FileInfo fi = new FileInfo(filePath);
                TotalBytes = fi.Length;
            }
        }
    }
}

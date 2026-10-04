using System;
using System.IO;
using System.Net.Sockets;

namespace XpressShare.Models
{
    public enum TransferSessionState
    {
        Pending,
        InProgress,
        Paused,
        Completed,
        Failed,
        Rejected,
        Cancelled
    }

    public class TransferSession : IDisposable
    {
        public Guid SessionId { get; set; }
        public string RemoteDeviceId { get; set; }
        public string RemoteDeviceName { get; set; }
        public string RemoteIpAddress { get; set; }
        public int RemotePort { get; set; }
        public string FilePath { get; set; }
        public string FileName
        {
            get
            {
                if (string.IsNullOrEmpty(FilePath))
                    return string.Empty;
                try
                {
                    return Path.GetFileName(FilePath);
                }
                catch
                {
                    return FilePath;
                }
            }
        }
        public long TotalBytes { get; set; }
        public long TransferredBytes { get; set; }
        public TransferSessionState State { get; set; }
        public DateTime StartTime { get; set; }
        public bool IsUpload { get; set; }
        public TcpClient Socket { get; set; }

        public TransferSession()
        {
            SessionId = Guid.NewGuid();
            State = TransferSessionState.Pending;
            StartTime = DateTime.UtcNow;
            TransferredBytes = 0;
            TotalBytes = 0;
            RemoteDeviceId = string.Empty;
            RemoteDeviceName = string.Empty;
            RemoteIpAddress = string.Empty;
            FilePath = string.Empty;
        }

        public double Progress
        {
            get
            {
                if (TotalBytes <= 0)
                    return 0.0;
                double pct = ((double)TransferredBytes * 100.0) / (double)TotalBytes;
                if (pct < 0.0) return 0.0;
                if (pct > 100.0) return 100.0;
                return pct;
            }
        }

        public TimeSpan ElapsedTime
        {
            get
            {
                return DateTime.UtcNow - StartTime;
            }
        }

        public double Speed
        {
            get
            {
                TimeSpan elapsed = ElapsedTime;
                if (elapsed.TotalSeconds <= 0.001)
                    return 0.0;
                return (double)TransferredBytes / elapsed.TotalSeconds; // bytes per second
            }
        }

        public double TransferRate
        {
            get { return Speed; }
        }

        public TimeSpan EstimatedTimeRemaining
        {
            get
            {
                double speed = Speed;
                if (speed <= 0.001)
                    return TimeSpan.Zero;

                long remainingBytes = TotalBytes - TransferredBytes;
                if (remainingBytes <= 0)
                    return TimeSpan.Zero;

                double secondsRemaining = (double)remainingBytes / speed;
                if (secondsRemaining > 86400 * 365) // Cap at 1 year
                    return TimeSpan.FromDays(365);

                return TimeSpan.FromSeconds(secondsRemaining);
            }
        }

        public double GetProgress()
        {
            return Progress;
        }

        public TimeSpan GetElapsedTime()
        {
            return ElapsedTime;
        }

        public double GetTransferSpeed()
        {
            return Speed;
        }

        public TimeSpan GetEstimatedTimeRemaining()
        {
            return EstimatedTimeRemaining;
        }

        public void Dispose()
        {
            if (Socket != null)
            {
                try
                {
                    Socket.Close();
                }
                catch
                {
                }
                Socket = null;
            }
        }
    }
}

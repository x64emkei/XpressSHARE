using System;
using XpressShare.Network;

namespace XpressShare.Transfers
{
    /// <summary>
    /// Represents an active live transfer session over a TcpConnection.
    /// Tracks transfer throughput, ETA, chunk sequencing, and pause/cancellation states.
    /// </summary>
    public class TransferSession : IDisposable
    {
        public Guid SessionId { get; set; }
        public TransferItem Item { get; set; }
        public TcpConnection Connection { get; set; }
        public int ChunkSize { get; set; }
        public long ResumeOffset { get; set; }
        public DateTime StartTime { get; set; }

        private DateTime _lastSampleTime;
        private long _lastSampleBytes;
        private double _smoothedSpeed;
        private volatile bool _isPaused;
        private volatile bool _isCancelled;

        public bool IsPaused { get { return _isPaused; } }
        public bool IsCancelled { get { return _isCancelled; } }

        public double SpeedBytesPerSec
        {
            get { return _smoothedSpeed; }
        }

        public TimeSpan EstimatedTimeRemaining
        {
            get
            {
                if (_smoothedSpeed <= 1024 || Item == null || Item.TotalBytes <= 0)
                    return TimeSpan.Zero;

                long remainingBytes = Item.TotalBytes - Item.TransferredBytes;
                if (remainingBytes <= 0) return TimeSpan.Zero;

                double seconds = remainingBytes / _smoothedSpeed;
                if (seconds > 86400 * 7) return TimeSpan.FromDays(7); // Cap at 7 days
                return TimeSpan.FromSeconds(seconds);
            }
        }

        public TransferSession(TransferItem item, TcpConnection conn, int chunkSize)
        {
            if (item == null) throw new ArgumentNullException("item");
            SessionId = Guid.NewGuid();
            Item = item;
            Connection = conn;
            ChunkSize = chunkSize > 0 ? chunkSize : 64 * 1024;
            ResumeOffset = 0;
            StartTime = DateTime.UtcNow;
            _lastSampleTime = DateTime.UtcNow;
            _lastSampleBytes = 0;
            _smoothedSpeed = 0;
        }

        public void Pause()
        {
            _isPaused = true;
            if (Item != null) Item.Status = TransferStatus.Paused;
        }

        public void Resume()
        {
            _isPaused = false;
            if (Item != null) Item.Status = TransferStatus.InProgress;
        }

        public void Cancel()
        {
            _isCancelled = true;
            if (Item != null) Item.Status = TransferStatus.Cancelled;
        }

        public void UpdateProgress(long bytesTransferred)
        {
            if (Item == null) return;
            Item.TransferredBytes = bytesTransferred;

            DateTime now = DateTime.UtcNow;
            double elapsedSec = (now - _lastSampleTime).TotalSeconds;

            if (elapsedSec >= 0.5)
            {
                long bytesDelta = bytesTransferred - _lastSampleBytes;
                if (bytesDelta >= 0)
                {
                    double instantSpeed = bytesDelta / elapsedSec;
                    _smoothedSpeed = _smoothedSpeed <= 0 ? instantSpeed : (0.3 * instantSpeed) + (0.7 * _smoothedSpeed);
                    Item.SpeedBytesPerSec = _smoothedSpeed;
                }
                _lastSampleTime = now;
                _lastSampleBytes = bytesTransferred;
            }
        }

        public void Dispose()
        {
            if (Connection != null)
            {
                Connection.Dispose();
                Connection = null;
            }
        }
    }
}

using System;
using System.Diagnostics;
using XpressShare.Utilities;

namespace XpressShare.Network
{
    /// <summary>
    /// Measures actual link throughput and round-trip latency to inform adaptive transfer tuning.
    /// Uses exponential moving averages (EMA) to avoid abrupt parameter flapping.
    /// </summary>
    public class NetworkCapabilities
    {
        private double _smoothedThroughputBytesPerSec;
        private double _smoothedRttMs;
        private const double Alpha = 0.2; // Smoothing factor for EMA
        private readonly object _lock = new object();

        public double CurrentThroughputBytesPerSec
        {
            get { lock (_lock) return _smoothedThroughputBytesPerSec; }
        }

        public double CurrentRttMs
        {
            get { lock (_lock) return _smoothedRttMs; }
        }

        public NetworkCapabilities()
        {
            _smoothedThroughputBytesPerSec = 0;
            _smoothedRttMs = 5.0; // Assume 5ms LAN default
        }

        /// <summary>
        /// Records an observed data transfer sample.
        /// </summary>
        public void RecordTransferSample(long bytes, double durationSeconds)
        {
            if (bytes <= 0 || durationSeconds <= 0.001) return;

            double sampleBps = bytes / durationSeconds;

            lock (_lock)
            {
                if (_smoothedThroughputBytesPerSec <= 0)
                {
                    _smoothedThroughputBytesPerSec = sampleBps;
                }
                else
                {
                    _smoothedThroughputBytesPerSec = (Alpha * sampleBps) + ((1.0 - Alpha) * _smoothedThroughputBytesPerSec);
                }
            }
        }

        /// <summary>
        /// Records an observed round-trip ping/pong sample.
        /// </summary>
        public void RecordRttSample(double rttMilliseconds)
        {
            if (rttMilliseconds < 0) return;

            lock (_lock)
            {
                _smoothedRttMs = (Alpha * rttMilliseconds) + ((1.0 - Alpha) * _smoothedRttMs);
            }
        }

        public string GetNetworkSummary(SystemCapabilities caps)
        {
            lock (_lock)
            {
                double mbps = (_smoothedThroughputBytesPerSec * 8.0) / 1000000.0;
                string adapter = caps != null ? caps.ActiveAdapterName : "Network Adapter";
                string medium = caps != null ? caps.ActiveNetworkMedium.ToString() : "LAN";

                if (_smoothedThroughputBytesPerSec > 0)
                {
                    return string.Format("{0} ({1}) - Measured: {2:0.0} Mbps, RTT: {3:0.0}ms",
                        adapter, medium, mbps, _smoothedRttMs);
                }
                return string.Format("{0} ({1}) - Link: {2} Mbps",
                    adapter, medium, caps != null && caps.LinkSpeedBps > 0 ? (caps.LinkSpeedBps / 1000000).ToString() : "N/A");
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace XpressShare.Utilities
{
    /// <summary>
    /// Thread-safe, bucketed reusable buffer pool compatible with .NET 3.5.
    /// Crucial for low-end hardware (Pentium 4, 512MB–1GB RAM) to prevent
    /// Large Object Heap (LOH) fragmentation, high memory allocation, and GC pauses.
    /// </summary>
    public class BufferPool
    {
        // Standard bucket sizes: 16KB, 32KB, 64KB, 128KB, 256KB, 1MB
        private static readonly int[] BucketSizes = new int[]
        {
            16 * 1024,
            32 * 1024,
            64 * 1024,
            128 * 1024,
            256 * 1024,
            1024 * 1024
        };

        private static readonly BufferPool _shared = new BufferPool();
        public static BufferPool Shared { get { return _shared; } }

        private readonly Dictionary<int, Queue<byte[]>> _pools;
        private readonly Dictionary<int, int> _maxPerBucket;
        private readonly object _lock = new object();

        public BufferPool()
        {
            _pools = new Dictionary<int, Queue<byte[]>>();
            _maxPerBucket = new Dictionary<int, int>();

            foreach (int size in BucketSizes)
            {
                _pools[size] = new Queue<byte[]>();
                // Conservative upper bounds to protect 512MB RAM systems
                if (size <= 64 * 1024)
                    _maxPerBucket[size] = 16;
                else if (size <= 256 * 1024)
                    _maxPerBucket[size] = 8;
                else
                    _maxPerBucket[size] = 4;
            }
        }

        /// <summary>
        /// Rents a reusable buffer of at least minSize bytes.
        /// </summary>
        public byte[] Rent(int minSize)
        {
            if (minSize <= 0)
                minSize = 64 * 1024;

            int bucketSize = SelectBucket(minSize);

            lock (_lock)
            {
                Queue<byte[]> queue;
                if (_pools.TryGetValue(bucketSize, out queue) && queue.Count > 0)
                {
                    return queue.Dequeue();
                }
            }

            // Allocate fresh buffer if pool is empty or size exceeds predefined buckets
            return new byte[bucketSize];
        }

        /// <summary>
        /// Returns a rented buffer to the pool for reuse.
        /// </summary>
        public void Return(byte[] buffer)
        {
            if (buffer == null)
                return;

            int size = buffer.Length;

            lock (_lock)
            {
                Queue<byte[]> queue;
                int maxCount;
                if (_pools.TryGetValue(size, out queue) && _maxPerBucket.TryGetValue(size, out maxCount))
                {
                    if (queue.Count < maxCount)
                    {
                        // Clean buffer headers / zero out for security hygiene if needed
                        Array.Clear(buffer, 0, Math.Min(buffer.Length, 128));
                        queue.Enqueue(buffer);
                    }
                }
            }
        }

        /// <summary>
        /// Clears all pooled buffers to free memory under low-resource pressure.
        /// </summary>
        public void Clear()
        {
            lock (_lock)
            {
                foreach (Queue<byte[]> queue in _pools.Values)
                {
                    queue.Clear();
                }
            }
        }

        private static int SelectBucket(int minSize)
        {
            for (int i = 0; i < BucketSizes.Length; i++)
            {
                if (BucketSizes[i] >= minSize)
                    return BucketSizes[i];
            }
            return minSize;
        }
    }
}

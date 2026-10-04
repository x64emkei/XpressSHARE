using System;

namespace XpressShare.Utilities
{
    /// <summary>
    /// Standard IEEE 802.3 32-bit CRC implementation for accidental packet corruption detection.
    /// Fast table-driven computation with zero memory allocation in the calculation loop.
    /// Note: CRC32 is purely for corruption detection and is not a cryptographic security primitive.
    /// </summary>
    public static class Crc32
    {
        private const uint Polynomial = 0xEDB88320;
        private static readonly uint[] Table;

        static Crc32()
        {
            Table = new uint[256];
            for (uint i = 0; i < 256; i++)
            {
                uint entry = i;
                for (int j = 0; j < 8; j++)
                {
                    if ((entry & 1) == 1)
                        entry = (entry >> 1) ^ Polynomial;
                    else
                        entry >>= 1;
                }
                Table[i] = entry;
            }
        }

        /// <summary>
        /// Computes CRC32 checksum over the specified byte array segment.
        /// </summary>
        public static uint Compute(byte[] buffer, int offset, int count)
        {
            if (buffer == null || count <= 0)
                return 0;

            uint crc = 0xFFFFFFFF;
            int end = offset + count;
            for (int i = offset; i < end; i++)
            {
                byte index = (byte)((crc ^ buffer[i]) & 0xFF);
                crc = (crc >> 8) ^ Table[index];
            }

            return ~crc;
        }

        /// <summary>
        /// Computes CRC32 checksum over the entire byte array.
        /// </summary>
        public static uint Compute(byte[] buffer)
        {
            if (buffer == null) return 0;
            return Compute(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Rolling CRC32 update step.
        /// </summary>
        public static uint Update(uint currentCrc, byte[] buffer, int offset, int count)
        {
            if (buffer == null || count <= 0)
                return currentCrc;

            uint crc = ~currentCrc;
            int end = offset + count;
            for (int i = offset; i < end; i++)
            {
                byte index = (byte)((crc ^ buffer[i]) & 0xFF);
                crc = (crc >> 8) ^ Table[index];
            }

            return ~crc;
        }
    }
}

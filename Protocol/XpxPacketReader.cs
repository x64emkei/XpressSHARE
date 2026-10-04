using System;
using System.IO;
using XpressShare.Utilities;

namespace XpressShare.Protocol
{
    /// <summary>
    /// Reads and validates XPX binary packets from a Stream or NetworkStream.
    /// Strictly rejects malformed packets, invalid magic, oversized payloads, and corrupted data.
    /// </summary>
    public class XpxPacketReader
    {
        private readonly byte[] _headerBuffer = new byte[XpxProtocolConstants.HeaderLength];

        /// <summary>
        /// Reads the next XPX packet from the stream.
        /// Returns null if connection is cleanly closed at packet boundary (EOF).
        /// Throws InvalidDataException on protocol violations.
        /// </summary>
        public XpxPacket ReadPacket(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException("stream");

            // 1. Read fixed 42-byte header
            int bytesRead = ReadExact(stream, _headerBuffer, 0, XpxProtocolConstants.HeaderLength, true);
            if (bytesRead == 0)
            {
                // Clean EOF at start of packet
                return null;
            }

            if (bytesRead < XpxProtocolConstants.HeaderLength)
            {
                throw new InvalidDataException("Premature end of stream while reading XPX packet header.");
            }

            // 2. Deserialize & Validate Header
            XpxHeader header = XpxHeader.ReadFrom(_headerBuffer, 0);
            string validationError;
            if (!header.Validate(out validationError))
            {
                throw new InvalidDataException("XPX Header validation failed: " + validationError);
            }

            // 3. Skip extended header bytes if any (for future-proofing)
            if (header.HeaderLength > XpxProtocolConstants.HeaderLength)
            {
                int extra = header.HeaderLength - XpxProtocolConstants.HeaderLength;
                byte[] skipBuffer = new byte[Math.Min(extra, 4096)];
                int remaining = extra;
                while (remaining > 0)
                {
                    int toRead = Math.Min(remaining, skipBuffer.Length);
                    if (ReadExact(stream, skipBuffer, 0, toRead, false) < toRead)
                        throw new InvalidDataException("Premature end of stream while reading extended header.");
                    remaining -= toRead;
                }
            }

            // 4. Read Payload (bounded by hard maximum)
            byte[] payload = null;
            if (header.PayloadLength > 0)
            {
                payload = new byte[header.PayloadLength];
                if (ReadExact(stream, payload, 0, (int)header.PayloadLength, false) < (int)header.PayloadLength)
                {
                    throw new InvalidDataException("Premature end of stream while reading packet payload.");
                }

                // Verify CRC32 for accidental corruption detection
                uint computedCrc = Crc32.Compute(payload, 0, payload.Length);
                if (computedCrc != header.Crc32)
                {
                    throw new InvalidDataException(string.Format(
                        "XPX Packet CRC32 mismatch! Expected 0x{0:X8}, Computed 0x{1:X8}. Packet discarded.",
                        header.Crc32, computedCrc));
                }
            }

            // 5. Read HMAC if packet has Encrypted flag set
            byte[] hmac = null;
            if ((header.Flags & XpxPacketFlags.Encrypted) != 0)
            {
                hmac = new byte[XpxProtocolConstants.HmacLength];
                if (ReadExact(stream, hmac, 0, XpxProtocolConstants.HmacLength, false) < XpxProtocolConstants.HmacLength)
                {
                    throw new InvalidDataException("Premature end of stream while reading packet HMAC.");
                }
            }

            return new XpxPacket(header, payload, hmac);
        }

        /// <summary>
        /// Reads exactly count bytes into buffer starting at offset.
        /// If allowEofOnFirstByte is true and EOF is encountered on the first read, returns 0.
        /// </summary>
        public static int ReadExact(Stream stream, byte[] buffer, int offset, int count, bool allowEofOnFirstByte)
        {
            if (stream == null || buffer == null || count <= 0)
                return 0;

            int totalRead = 0;
            while (totalRead < count)
            {
                int read = stream.Read(buffer, offset + totalRead, count - totalRead);
                if (read <= 0)
                {
                    if (totalRead == 0 && allowEofOnFirstByte)
                        return 0;
                    return totalRead; // Truncated
                }
                totalRead += read;
            }
            return totalRead;
        }
    }
}

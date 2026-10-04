using System;
using System.IO;
using XpressShare.Utilities;

namespace XpressShare.Protocol
{
    /// <summary>
    /// Writes XPX binary packets deterministically to a Stream or NetworkStream.
    /// Thread-safe per stream instance via internal locking.
    /// </summary>
    public class XpxPacketWriter
    {
        private readonly object _writeLock = new object();

        public void WritePacket(Stream stream, XpxPacket packet)
        {
            if (stream == null) throw new ArgumentNullException("stream");
            if (packet == null) throw new ArgumentNullException("packet");
            if (packet.Header == null) throw new ArgumentException("Packet must have a valid Header.");

            lock (_writeLock)
            {
                byte[] payload = packet.Payload;
                uint payloadLength = payload != null ? (uint)payload.Length : 0;
                packet.Header.PayloadLength = payloadLength;

                // Calculate CRC32 of payload for corruption detection (if payload present)
                if (payload != null && payload.Length > 0)
                {
                    packet.Header.Crc32 = Crc32.Compute(payload, 0, payload.Length);
                }
                else
                {
                    packet.Header.Crc32 = 0;
                }

                // Prepare header buffer
                byte[] headerBuffer = new byte[XpxProtocolConstants.HeaderLength];
                packet.Header.WriteTo(headerBuffer, 0);

                // Write header
                stream.Write(headerBuffer, 0, headerBuffer.Length);

                // Write payload if present
                if (payload != null && payload.Length > 0)
                {
                    stream.Write(payload, 0, payload.Length);
                }

                // Write HMAC if present (32 bytes)
                if (packet.Hmac != null && packet.Hmac.Length == XpxProtocolConstants.HmacLength)
                {
                    stream.Write(packet.Hmac, 0, packet.Hmac.Length);
                }

                stream.Flush();
            }
        }
    }
}

using System;

namespace XpressShare.Protocol
{
    /// <summary>
    /// Strict 42-byte binary header for the XPX/1 application-layer protocol.
    /// Uses explicit big-endian (network byte order) integer serialization.
    /// </summary>
    public class XpxHeader
    {
        public uint Magic { get; set; }
        public byte Version { get; set; }
        public XpxPacketType PacketType { get; set; }
        public XpxPacketFlags Flags { get; set; }
        public ushort HeaderLength { get; set; }
        public uint PayloadLength { get; set; }
        public ulong PacketId { get; set; }
        public Guid SessionId { get; set; }
        public uint Crc32 { get; set; }

        public XpxHeader()
        {
            Magic = XpxProtocolConstants.Magic;
            Version = XpxProtocolConstants.ProtocolVersion;
            PacketType = XpxPacketType.Unknown;
            Flags = XpxPacketFlags.None;
            HeaderLength = XpxProtocolConstants.HeaderLength;
            PayloadLength = 0;
            PacketId = 0;
            SessionId = Guid.Empty;
            Crc32 = 0;
        }

        public XpxHeader(XpxPacketType packetType, ulong packetId, Guid sessionId)
            : this()
        {
            PacketType = packetType;
            PacketId = packetId;
            SessionId = sessionId;
        }

        /// <summary>
        /// Validates header fields against protocol constraints.
        /// </summary>
        public bool Validate(out string errorMessage)
        {
            if (Magic != XpxProtocolConstants.Magic)
            {
                errorMessage = string.Format("Invalid XPX magic: 0x{0:X8} (expected 0x{1:X8})", Magic, XpxProtocolConstants.Magic);
                return false;
            }

            if (Version != XpxProtocolConstants.ProtocolVersion)
            {
                errorMessage = string.Format("Unsupported protocol version: {0} (expected {1})", Version, XpxProtocolConstants.ProtocolVersion);
                return false;
            }

            if (HeaderLength < XpxProtocolConstants.HeaderLength)
            {
                errorMessage = string.Format("Invalid header length: {0} (minimum {1})", HeaderLength, XpxProtocolConstants.HeaderLength);
                return false;
            }

            if (PayloadLength > XpxProtocolConstants.MaxPayloadLength)
            {
                errorMessage = string.Format("Payload length exceeds limit: {0} bytes (max {1})", PayloadLength, XpxProtocolConstants.MaxPayloadLength);
                return false;
            }

            errorMessage = null;
            return true;
        }

        /// <summary>
        /// Serializes the 42-byte binary header into the destination buffer.
        /// </summary>
        public void WriteTo(byte[] buffer, int offset)
        {
            if (buffer == null) throw new ArgumentNullException("buffer");
            if (offset < 0 || offset + XpxProtocolConstants.HeaderLength > buffer.Length)
                throw new ArgumentOutOfRangeException("offset", "Buffer is too small for XPX header.");

            WriteUInt32BigEndian(buffer, offset + 0, Magic);
            buffer[offset + 4] = Version;
            buffer[offset + 5] = (byte)PacketType;
            WriteUInt16BigEndian(buffer, offset + 6, (ushort)Flags);
            WriteUInt16BigEndian(buffer, offset + 8, HeaderLength);
            WriteUInt32BigEndian(buffer, offset + 10, PayloadLength);
            WriteUInt64BigEndian(buffer, offset + 14, PacketId);

            byte[] guidBytes = SessionId.ToByteArray();
            Buffer.BlockCopy(guidBytes, 0, buffer, offset + 22, 16);

            WriteUInt32BigEndian(buffer, offset + 38, Crc32);
        }

        /// <summary>
        /// Deserializes an XPX header from a binary buffer.
        /// </summary>
        public static XpxHeader ReadFrom(byte[] buffer, int offset)
        {
            if (buffer == null) throw new ArgumentNullException("buffer");
            if (offset < 0 || offset + XpxProtocolConstants.HeaderLength > buffer.Length)
                throw new ArgumentOutOfRangeException("offset", "Buffer is too small for XPX header.");

            XpxHeader header = new XpxHeader();
            header.Magic = ReadUInt32BigEndian(buffer, offset + 0);
            header.Version = buffer[offset + 4];
            header.PacketType = (XpxPacketType)buffer[offset + 5];
            header.Flags = (XpxPacketFlags)ReadUInt16BigEndian(buffer, offset + 6);
            header.HeaderLength = ReadUInt16BigEndian(buffer, offset + 8);
            header.PayloadLength = ReadUInt32BigEndian(buffer, offset + 10);
            header.PacketId = ReadUInt64BigEndian(buffer, offset + 14);

            byte[] guidBytes = new byte[16];
            Buffer.BlockCopy(buffer, offset + 22, guidBytes, 0, 16);
            header.SessionId = new Guid(guidBytes);

            header.Crc32 = ReadUInt32BigEndian(buffer, offset + 38);

            return header;
        }

        #region Big-Endian Byte Helpers

        public static void WriteUInt16BigEndian(byte[] buffer, int offset, ushort value)
        {
            buffer[offset + 0] = (byte)((value >> 8) & 0xFF);
            buffer[offset + 1] = (byte)(value & 0xFF);
        }

        public static ushort ReadUInt16BigEndian(byte[] buffer, int offset)
        {
            return (ushort)((buffer[offset + 0] << 8) | buffer[offset + 1]);
        }

        public static void WriteUInt32BigEndian(byte[] buffer, int offset, uint value)
        {
            buffer[offset + 0] = (byte)((value >> 24) & 0xFF);
            buffer[offset + 1] = (byte)((value >> 16) & 0xFF);
            buffer[offset + 2] = (byte)((value >> 8) & 0xFF);
            buffer[offset + 3] = (byte)(value & 0xFF);
        }

        public static uint ReadUInt32BigEndian(byte[] buffer, int offset)
        {
            return ((uint)buffer[offset + 0] << 24) |
                   ((uint)buffer[offset + 1] << 16) |
                   ((uint)buffer[offset + 2] << 8) |
                   ((uint)buffer[offset + 3]);
        }

        public static void WriteUInt64BigEndian(byte[] buffer, int offset, ulong value)
        {
            buffer[offset + 0] = (byte)((value >> 56) & 0xFF);
            buffer[offset + 1] = (byte)((value >> 48) & 0xFF);
            buffer[offset + 2] = (byte)((value >> 40) & 0xFF);
            buffer[offset + 3] = (byte)((value >> 32) & 0xFF);
            buffer[offset + 4] = (byte)((value >> 24) & 0xFF);
            buffer[offset + 5] = (byte)((value >> 16) & 0xFF);
            buffer[offset + 6] = (byte)((value >> 8) & 0xFF);
            buffer[offset + 7] = (byte)(value & 0xFF);
        }

        public static ulong ReadUInt64BigEndian(byte[] buffer, int offset)
        {
            return ((ulong)buffer[offset + 0] << 56) |
                   ((ulong)buffer[offset + 1] << 48) |
                   ((ulong)buffer[offset + 2] << 40) |
                   ((ulong)buffer[offset + 3] << 32) |
                   ((ulong)buffer[offset + 4] << 24) |
                   ((ulong)buffer[offset + 5] << 16) |
                   ((ulong)buffer[offset + 6] << 8) |
                   ((ulong)buffer[offset + 7]);
        }

        #endregion
    }
}

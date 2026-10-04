using System;
using System.Text;

namespace XpressShare.Protocol
{
    /// <summary>
    /// Represents a complete XPX/1 packet containing Header, optional Payload, and optional HMAC tag.
    /// </summary>
    public class XpxPacket
    {
        public XpxHeader Header { get; set; }
        public byte[] Payload { get; set; }
        public byte[] Hmac { get; set; }

        public XpxPacket()
        {
            Header = new XpxHeader();
            Payload = null;
            Hmac = null;
        }

        public XpxPacket(XpxHeader header, byte[] payload)
        {
            Header = header ?? new XpxHeader();
            Payload = payload;
            if (payload != null)
            {
                Header.PayloadLength = (uint)payload.Length;
            }
            Hmac = null;
        }

        public XpxPacket(XpxHeader header, byte[] payload, byte[] hmac)
            : this(header, payload)
        {
            Hmac = hmac;
        }

        public bool IsEncrypted
        {
            get { return (Header.Flags & XpxPacketFlags.Encrypted) != 0; }
        }

        public bool IsCompressed
        {
            get { return (Header.Flags & XpxPacketFlags.Compressed) != 0; }
        }

        public string GetPayloadAsString()
        {
            if (Payload == null || Payload.Length == 0)
                return string.Empty;
            return Encoding.UTF8.GetString(Payload);
        }

        public void SetPayloadFromString(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                Payload = new byte[0];
            }
            else
            {
                Payload = Encoding.UTF8.GetBytes(text);
            }
            Header.PayloadLength = (uint)Payload.Length;
        }

        #region Factory Methods

        public static XpxPacket CreateHeartbeat(ulong packetId, Guid sessionId)
        {
            XpxHeader header = new XpxHeader(XpxPacketType.Heartbeat, packetId, sessionId);
            return new XpxPacket(header, null);
        }

        public static XpxPacket CreateHeartbeatAck(ulong packetId, Guid sessionId)
        {
            XpxHeader header = new XpxHeader(XpxPacketType.HeartbeatAck, packetId, sessionId);
            header.Flags |= XpxPacketFlags.Response;
            return new XpxPacket(header, null);
        }

        public static XpxPacket CreateHello(ulong packetId, string clientNonceHex, string rsaPublicKeyXml, string deviceName, string osName)
        {
            XpxHeader header = new XpxHeader(XpxPacketType.Hello, packetId, Guid.Empty);
            string payload = string.Format("{0}\n{1}\n{2}\n{3}", clientNonceHex, deviceName, osName, rsaPublicKeyXml);
            XpxPacket pkt = new XpxPacket(header, null);
            pkt.SetPayloadFromString(payload);
            return pkt;
        }

        public static XpxPacket CreateHelloAck(ulong packetId, Guid sessionId, string serverNonceHex, string encryptedMasterSecretBase64, string deviceName, string osName)
        {
            XpxHeader header = new XpxHeader(XpxPacketType.HelloAck, packetId, sessionId);
            header.Flags |= XpxPacketFlags.Response;
            string payload = string.Format("{0}\n{1}\n{2}\n{3}", serverNonceHex, encryptedMasterSecretBase64, deviceName, osName);
            XpxPacket pkt = new XpxPacket(header, null);
            pkt.SetPayloadFromString(payload);
            return pkt;
        }

        public static XpxPacket CreateMessage(ulong packetId, Guid sessionId, string senderId, string messageText)
        {
            XpxHeader header = new XpxHeader(XpxPacketType.Message, packetId, sessionId);
            string payload = string.Format("{0}|{1:O}|{2}", senderId, DateTime.UtcNow, messageText ?? "");
            XpxPacket pkt = new XpxPacket(header, null);
            pkt.SetPayloadFromString(payload);
            return pkt;
        }

        public static XpxPacket CreateError(ulong packetId, Guid sessionId, string errorMessage)
        {
            XpxHeader header = new XpxHeader(XpxPacketType.Error, packetId, sessionId);
            header.Flags |= XpxPacketFlags.Error;
            XpxPacket pkt = new XpxPacket(header, null);
            pkt.SetPayloadFromString(errorMessage ?? "An unknown error occurred.");
            return pkt;
        }

        public static XpxPacket CreateDisconnect(ulong packetId, Guid sessionId, string reason)
        {
            XpxHeader header = new XpxHeader(XpxPacketType.Disconnect, packetId, sessionId);
            XpxPacket pkt = new XpxPacket(header, null);
            pkt.SetPayloadFromString(reason ?? "Normal disconnect");
            return pkt;
        }

        #endregion
    }
}

using System;
using System.Text;

namespace XpressShare.Network
{
    public class ProtocolMessage
    {
        public ProtocolMessageType Type { get; set; }
        public string SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderIp { get; set; }
        public string Payload { get; set; }

        public ProtocolMessage()
        {
            Type = ProtocolMessageType.Identity;
            SenderId = string.Empty;
            SenderName = string.Empty;
            SenderIp = string.Empty;
            Payload = string.Empty;
        }

        public byte[] Serialize()
        {
            // Simple text-based protocol: TYPE|SENDERID|SENDERNAME|SENDERIP|PAYLOAD
            // Pipe-delimited for simplicity and .NET 3.5 compatibility
            StringBuilder sb = new StringBuilder();
            sb.Append((int)Type).Append("|");
            sb.Append(EscapeField(SenderId)).Append("|");
            sb.Append(EscapeField(SenderName)).Append("|");
            sb.Append(EscapeField(SenderIp)).Append("|");
            sb.Append(EscapeField(Payload));

            return Encoding.UTF8.GetBytes(sb.ToString());
        }

        public static ProtocolMessage Deserialize(byte[] data)
        {
            if (data == null || data.Length == 0)
                return null;

            string text = Encoding.UTF8.GetString(data);
            string[] parts = text.Split(new char[] { '|' }, 5);

            if (parts.Length < 5)
                return null;

            try
            {
                int typeInt;
                if (!int.TryParse(parts[0], out typeInt))
                    return null;

                var msg = new ProtocolMessage
                {
                    Type = (ProtocolMessageType)typeInt,
                    SenderId = UnescapeField(parts[1]),
                    SenderName = UnescapeField(parts[2]),
                    SenderIp = UnescapeField(parts[3]),
                    Payload = UnescapeField(parts[4])
                };

                return msg;
            }
            catch
            {
                return null;
            }
        }

        private static string EscapeField(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";
            return value.Replace("\\", "\\\\").Replace("|", "\\|");
        }

        private static string UnescapeField(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";
            return value.Replace("\\|", "|").Replace("\\\\", "\\");
        }
    }
}

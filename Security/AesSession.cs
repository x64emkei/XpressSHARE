using System;
using System.IO;
using System.Security.Cryptography;
using XpressShare.Protocol;

namespace XpressShare.Security
{
    /// <summary>
    /// Manages authenticated symmetric encryption (AES-256-CBC + HMAC-SHA256) for an XPX session.
    /// Implements strict key separation: separate AES and HMAC keys for each direction.
    /// Compatible with .NET Framework 3.5 on Windows XP SP3 through Windows 11.
    /// </summary>
    public class AesSession : IDisposable
    {
        public Guid SessionId { get; private set; }
        public bool IsClient { get; private set; }

        private readonly byte[] _outgoingAesKey;
        private readonly byte[] _incomingAesKey;
        private readonly byte[] _outgoingHmacKey;
        private readonly byte[] _incomingHmacKey;

        private RijndaelManaged _aesOutgoing;
        private RijndaelManaged _aesIncoming;
        private bool _disposed;
        private readonly object _encryptLock = new object();
        private readonly object _decryptLock = new object();

        /// <summary>
        /// Creates an AesSession using derived directional keys.
        /// </summary>
        public AesSession(Guid sessionId, bool isClient,
            byte[] clientAesKey, byte[] serverAesKey,
            byte[] clientHmacKey, byte[] serverHmacKey)
        {
            if (sessionId == Guid.Empty) throw new ArgumentException("SessionId cannot be empty.", "sessionId");
            if (clientAesKey == null || clientAesKey.Length != 32) throw new ArgumentException("Client AES key must be 32 bytes.");
            if (serverAesKey == null || serverAesKey.Length != 32) throw new ArgumentException("Server AES key must be 32 bytes.");
            if (clientHmacKey == null || clientHmacKey.Length != 32) throw new ArgumentException("Client HMAC key must be 32 bytes.");
            if (serverHmacKey == null || serverHmacKey.Length != 32) throw new ArgumentException("Server HMAC key must be 32 bytes.");

            SessionId = sessionId;
            IsClient = isClient;

            if (isClient)
            {
                _outgoingAesKey = (byte[])clientAesKey.Clone();
                _incomingAesKey = (byte[])serverAesKey.Clone();
                _outgoingHmacKey = (byte[])clientHmacKey.Clone();
                _incomingHmacKey = (byte[])serverHmacKey.Clone();
            }
            else
            {
                _outgoingAesKey = (byte[])serverAesKey.Clone();
                _incomingAesKey = (byte[])clientAesKey.Clone();
                _outgoingHmacKey = (byte[])serverHmacKey.Clone();
                _incomingHmacKey = (byte[])clientHmacKey.Clone();
            }

            _aesOutgoing = CreateAesProvider(_outgoingAesKey);
            _aesIncoming = CreateAesProvider(_incomingAesKey);
        }

        private static RijndaelManaged CreateAesProvider(byte[] key)
        {
            RijndaelManaged aes = new RijndaelManaged();
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = key;
            return aes;
        }

        /// <summary>
        /// Encrypts an outgoing XPX packet payload using AES-256-CBC and attaches HMAC-SHA256 authentication tag.
        /// Construction: Encrypt-then-MAC.
        /// </summary>
        public void EncryptPacket(XpxPacket packet)
        {
            if (packet == null) throw new ArgumentNullException("packet");
            if (packet.Header == null) throw new ArgumentException("Packet Header cannot be null.");

            byte[] plaintext = packet.Payload ?? new byte[0];

            lock (_encryptLock)
            {
                CheckDisposed();

                // 1. Generate unique, unpredictable 16-byte IV
                byte[] iv = CryptoProvider.GenerateIv();

                // 2. Encrypt plaintext using AES-256-CBC
                byte[] ciphertext;
                using (ICryptoTransform encryptor = _aesOutgoing.CreateEncryptor(_outgoingAesKey, iv))
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(plaintext, 0, plaintext.Length);
                        cs.FlushFinalBlock();
                    }
                    ciphertext = ms.ToArray();
                }

                // 3. Assemble Payload: IV (16 bytes) + Ciphertext (N bytes)
                byte[] combinedPayload = new byte[iv.Length + ciphertext.Length];
                Buffer.BlockCopy(iv, 0, combinedPayload, 0, iv.Length);
                Buffer.BlockCopy(ciphertext, 0, combinedPayload, iv.Length, ciphertext.Length);

                packet.Payload = combinedPayload;
                packet.Header.PayloadLength = (uint)combinedPayload.Length;
                packet.Header.Flags |= XpxPacketFlags.Encrypted;

                // 4. Compute header bytes for MAC binding
                byte[] headerBytes = new byte[XpxProtocolConstants.HeaderLength];
                packet.Header.WriteTo(headerBytes, 0);

                // 5. Compute HMAC-SHA256 over Header + Combined Payload (Encrypt-then-MAC)
                packet.Hmac = HmacProvider.ComputeHmac(_outgoingHmacKey, headerBytes, combinedPayload);
            }
        }

        /// <summary>
        /// Verifies HMAC and decrypts an incoming encrypted XPX packet.
        /// Verifies HMAC BEFORE decrypting to prevent padding oracle and tampering attacks.
        /// </summary>
        public byte[] DecryptPacket(XpxPacket packet)
        {
            if (packet == null) throw new ArgumentNullException("packet");
            if (packet.Header == null) throw new ArgumentException("Packet Header cannot be null.");

            lock (_decryptLock)
            {
                CheckDisposed();

                if ((packet.Header.Flags & XpxPacketFlags.Encrypted) == 0)
                {
                    // Not encrypted, return raw payload
                    return packet.Payload;
                }

                byte[] combinedPayload = packet.Payload;
                if (combinedPayload == null || combinedPayload.Length < 16)
                {
                    throw new CryptographicException("Ciphertext payload is too short or missing IV.");
                }

                if (packet.Hmac == null || packet.Hmac.Length != XpxProtocolConstants.HmacLength)
                {
                    throw new CryptographicException("Missing or invalid HMAC authentication tag.");
                }

                // 1. Verify HMAC over Header + Payload before touching ciphertext
                byte[] headerBytes = new byte[XpxProtocolConstants.HeaderLength];
                packet.Header.WriteTo(headerBytes, 0);

                if (!HmacProvider.VerifyHmac(_incomingHmacKey, headerBytes, combinedPayload, packet.Hmac))
                {
                    throw new CryptographicException("HMAC verification failed! Packet data has been tampered with or corrupted.");
                }

                // 2. Extract IV (first 16 bytes) and Ciphertext
                byte[] iv = new byte[16];
                Buffer.BlockCopy(combinedPayload, 0, iv, 0, 16);

                int cipherLen = combinedPayload.Length - 16;
                byte[] plaintext;

                // 3. Decrypt ciphertext using AES-256-CBC
                using (ICryptoTransform decryptor = _aesIncoming.CreateDecryptor(_incomingAesKey, iv))
                using (MemoryStream msIn = new MemoryStream(combinedPayload, 16, cipherLen))
                using (CryptoStream cs = new CryptoStream(msIn, decryptor, CryptoStreamMode.Read))
                using (MemoryStream msOut = new MemoryStream())
                {
                    byte[] buffer = new byte[4096];
                    int read;
                    while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        msOut.Write(buffer, 0, read);
                    }
                    plaintext = msOut.ToArray();
                }

                return plaintext;
            }
        }

        private void CheckDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException("AesSession", "This cryptographic session has been disposed.");
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;

                if (_aesOutgoing != null)
                {
                    _aesOutgoing.Clear();
                    _aesOutgoing = null;
                }

                if (_aesIncoming != null)
                {
                    _aesIncoming.Clear();
                    _aesIncoming = null;
                }

                Array.Clear(_outgoingAesKey, 0, _outgoingAesKey.Length);
                Array.Clear(_incomingAesKey, 0, _incomingAesKey.Length);
                Array.Clear(_outgoingHmacKey, 0, _outgoingHmacKey.Length);
                Array.Clear(_incomingHmacKey, 0, _incomingHmacKey.Length);
            }
        }
    }
}

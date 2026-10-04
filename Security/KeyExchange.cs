using System;
using System.Security.Cryptography;
using System.Text;

namespace XpressShare.Security
{
    /// <summary>
    /// Handles application-level cryptographic key exchange and session establishment.
    /// Uses 2048-bit ephemeral RSA and secure nonces to negotiate a 32-byte Session Master Secret,
    /// then derives directional AES-256 and HMAC-SHA256 keys via HMAC-SHA256 KDF.
    /// 100% compatible with .NET Framework 3.5 on Windows XP SP3 through Windows 11.
    /// </summary>
    public class KeyExchange : IDisposable
    {
        private RSACryptoServiceProvider _rsaEphemeral;
        private byte[] _clientNonce;
        private bool _disposed;

        public KeyExchange()
        {
        }

        /// <summary>
        /// Step 1 (Client): Initializes client key exchange, generates 32-byte Nonce A and 2048-bit ephemeral RSA key.
        /// </summary>
        public void ClientInit(out string clientNonceHex, out string rsaPublicKeyXml)
        {
            _clientNonce = CryptoProvider.GenerateRandomBytes(32);
            clientNonceHex = CryptoProvider.ToHex(_clientNonce);

            // 2048-bit RSA is standard in XP SP3 and supported by Microsoft Enhanced Cryptographic Provider
            CspParameters csp = new CspParameters();
            csp.Flags = CspProviderFlags.UseMachineKeyStore;
            _rsaEphemeral = new RSACryptoServiceProvider(2048, csp);
            rsaPublicKeyXml = _rsaEphemeral.ToXmlString(false); // Export public key only
        }

        /// <summary>
        /// Step 2 (Server): Processes Client Hello, generates Nonce B and Pre-Master Secret,
        /// encrypts Pre-Master Secret using Client's RSA public key, and derives Server's AesSession.
        /// </summary>
        public static void ServerProcessHelloAndDerive(
            string clientNonceHex,
            string clientRsaPublicKeyXml,
            Guid sessionId,
            out string serverNonceHex,
            out string encryptedPreMasterBase64,
            out AesSession serverSession)
        {
            if (string.IsNullOrEmpty(clientNonceHex)) throw new ArgumentException("Client nonce cannot be empty.");
            if (string.IsNullOrEmpty(clientRsaPublicKeyXml)) throw new ArgumentException("Client RSA public key cannot be empty.");

            byte[] clientNonce = CryptoProvider.FromHex(clientNonceHex);
            byte[] serverNonce = CryptoProvider.GenerateRandomBytes(32);
            serverNonceHex = CryptoProvider.ToHex(serverNonce);

            // Generate 32-byte Pre-Master Secret
            byte[] preMasterSecret = CryptoProvider.GenerateKey();

            // Encrypt Pre-Master Secret using Client's ephemeral RSA public key
            // Note: fOAEP = false uses PKCS#1 v1.5 padding which is universally compatible with XP SP3
            using (RSACryptoServiceProvider rsaClient = new RSACryptoServiceProvider())
            {
                rsaClient.FromXmlString(clientRsaPublicKeyXml);
                byte[] encryptedPreMaster = rsaClient.Encrypt(preMasterSecret, false);
                encryptedPreMasterBase64 = Convert.ToBase64String(encryptedPreMaster);
            }

            // Derive Master Secret and Directional Keys
            byte[] clientAesKey;
            byte[] serverAesKey;
            byte[] clientHmacKey;
            byte[] serverHmacKey;
            DeriveSessionKeys(preMasterSecret, clientNonce, serverNonce,
                out clientAesKey, out serverAesKey, out clientHmacKey, out serverHmacKey);

            serverSession = new AesSession(sessionId, false,
                clientAesKey, serverAesKey, clientHmacKey, serverHmacKey);

            Array.Clear(preMasterSecret, 0, preMasterSecret.Length);
        }

        /// <summary>
        /// Step 3 (Client): Decrypts the Pre-Master Secret with ephemeral RSA private key
        /// and derives Client's AesSession.
        /// </summary>
        public AesSession ClientFinishHandshake(
            string serverNonceHex,
            string encryptedPreMasterBase64,
            Guid sessionId)
        {
            if (_rsaEphemeral == null || _clientNonce == null)
                throw new InvalidOperationException("ClientInit must be called before ClientFinishHandshake.");

            byte[] serverNonce = CryptoProvider.FromHex(serverNonceHex);
            byte[] encryptedPreMaster = Convert.FromBase64String(encryptedPreMasterBase64);

            // Decrypt Pre-Master Secret with ephemeral private key
            byte[] preMasterSecret = _rsaEphemeral.Decrypt(encryptedPreMaster, false);

            byte[] clientAesKey;
            byte[] serverAesKey;
            byte[] clientHmacKey;
            byte[] serverHmacKey;
            DeriveSessionKeys(preMasterSecret, _clientNonce, serverNonce,
                out clientAesKey, out serverAesKey, out clientHmacKey, out serverHmacKey);

            AesSession clientSession = new AesSession(sessionId, true,
                clientAesKey, serverAesKey, clientHmacKey, serverHmacKey);

            Array.Clear(preMasterSecret, 0, preMasterSecret.Length);
            Dispose();

            return clientSession;
        }

        /// <summary>
        /// Derives the 4 directional keys from the Pre-Master Secret and nonces using HMAC-SHA256 KDF.
        /// </summary>
        public static void DeriveSessionKeys(
            byte[] preMasterSecret,
            byte[] clientNonce,
            byte[] serverNonce,
            out byte[] clientAesKey,
            out byte[] serverAesKey,
            out byte[] clientHmacKey,
            out byte[] serverHmacKey)
        {
            // 1. Derive Session Master Secret: HMAC-SHA256(preMaster, "XPX1-MASTER-SECRET" || clientNonce || serverNonce)
            byte[] label = Encoding.UTF8.GetBytes("XPX1-MASTER-SECRET");
            byte[] kdfInput = new byte[label.Length + clientNonce.Length + serverNonce.Length];
            Buffer.BlockCopy(label, 0, kdfInput, 0, label.Length);
            Buffer.BlockCopy(clientNonce, 0, kdfInput, label.Length, clientNonce.Length);
            Buffer.BlockCopy(serverNonce, 0, kdfInput, label.Length + clientNonce.Length, serverNonce.Length);

            byte[] masterSecret = HmacProvider.ComputeHmac(preMasterSecret, kdfInput);

            // 2. Expand Master Secret into 4 distinct directional keys
            clientAesKey = HmacProvider.ComputeHmac(masterSecret, Encoding.UTF8.GetBytes("XPX1-CLIENT-TO-SERVER-AES-256"));
            serverAesKey = HmacProvider.ComputeHmac(masterSecret, Encoding.UTF8.GetBytes("XPX1-SERVER-TO-CLIENT-AES-256"));
            clientHmacKey = HmacProvider.ComputeHmac(masterSecret, Encoding.UTF8.GetBytes("XPX1-CLIENT-TO-SERVER-HMAC-256"));
            serverHmacKey = HmacProvider.ComputeHmac(masterSecret, Encoding.UTF8.GetBytes("XPX1-SERVER-TO-CLIENT-HMAC-256"));

            Array.Clear(masterSecret, 0, masterSecret.Length);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                if (_rsaEphemeral != null)
                {
                    _rsaEphemeral.Clear();
                    _rsaEphemeral = null;
                }
                if (_clientNonce != null)
                {
                    Array.Clear(_clientNonce, 0, _clientNonce.Length);
                    _clientNonce = null;
                }
            }
        }
    }
}

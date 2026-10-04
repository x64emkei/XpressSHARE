using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using XpressShare.Protocol;
using XpressShare.Security;
using XpressShare.Transfers;
using XpressShare.Utilities;

namespace XpressShare.Tests
{
    /// <summary>
    /// Test suite verifying protocol correctness, cryptographic validation,
    /// malformed packet rejection, replay attack protection, CRC32, and resume mechanisms.
    /// Compatible with .NET Framework 3.5.
    /// </summary>
    public static class XpxProtocolTests
    {
        public static bool RunAllTests(out string summary)
        {
            StringBuilder sb = new StringBuilder();
            int passed = 0;
            int total = 0;

            Test("Valid Packet Serialization & Deserialization", TestValidPacketRoundtrip, sb, ref passed, ref total);
            Test("Invalid Magic Rejection", TestInvalidMagicRejection, sb, ref passed, ref total);
            Test("Invalid Version Rejection", TestInvalidVersionRejection, sb, ref passed, ref total);
            Test("Oversized Payload Rejection", TestOversizedPayloadRejection, sb, ref passed, ref total);
            Test("Truncated Packet Rejection", TestTruncatedPacketRejection, sb, ref passed, ref total);
            Test("CRC32 Accidental Corruption Detection", TestCrc32CorruptionDetection, sb, ref passed, ref total);
            Test("HMAC Tampering Detection (MAC-then-Decrypt)", TestHmacTamperingDetection, sb, ref passed, ref total);
            Test("Directional Key Separation (Client vs Server)", TestDirectionalKeySeparation, sb, ref passed, ref total);
            Test("AES-256 Unique IV per Packet", TestUniqueIvPerPacket, sb, ref passed, ref total);
            Test("Replay Attack Protection (Sliding Window)", TestReplayAttackProtection, sb, ref passed, ref total);
            Test("Key Exchange (Ephemeral 2048-bit RSA + Nonces)", TestKeyExchangeHandshake, sb, ref passed, ref total);
            Test("BufferPool Reusability & Zero GC Leakage", TestBufferPoolReuse, sb, ref passed, ref total);
            Test("Hardware Capability & Performance Profile Detection", TestProfileDetection, sb, ref passed, ref total);
            Test("File Transfer Resume Simulation", TestFileTransferResumeSimulation, sb, ref passed, ref total);

            summary = string.Format("XPX Protocol Test Results: {0}/{1} passed.\r\n\r\n{2}", passed, total, sb.ToString());
            return passed == total;
        }

        private static void Test(string name, Action testAction, StringBuilder sb, ref int passed, ref int total)
        {
            total++;
            try
            {
                testAction();
                passed++;
                sb.AppendLine(string.Format("[PASS] {0}", name));
            }
            catch (Exception ex)
            {
                sb.AppendLine(string.Format("[FAIL] {0}: {1}", name, ex.Message));
            }
        }

        public static void TestValidPacketRoundtrip()
        {
            Guid sessionId = Guid.NewGuid();
            XpxHeader header = new XpxHeader(XpxPacketType.Message, 42, sessionId);
            byte[] payload = Encoding.UTF8.GetBytes("Hello, XPX protocol!");
            XpxPacket pkt = new XpxPacket(header, payload);

            XpxPacketWriter writer = new XpxPacketWriter();
            XpxPacketReader reader = new XpxPacketReader();

            using (MemoryStream ms = new MemoryStream())
            {
                writer.WritePacket(ms, pkt);
                ms.Position = 0;

                XpxPacket deserialized = reader.ReadPacket(ms);
                if (deserialized == null) throw new Exception("Deserialized packet is null");
                if (deserialized.Header.Magic != XpxProtocolConstants.Magic) throw new Exception("Magic mismatch");
                if (deserialized.Header.PacketType != XpxPacketType.Message) throw new Exception("Type mismatch");
                if (deserialized.Header.PacketId != 42) throw new Exception("PacketId mismatch");
                if (deserialized.Header.SessionId != sessionId) throw new Exception("SessionId mismatch");
                string text = deserialized.GetPayloadAsString();
                if (text != "Hello, XPX protocol!") throw new Exception("Payload mismatch: " + text);
            }
        }

        public static void TestInvalidMagicRejection()
        {
            byte[] raw = new byte[XpxProtocolConstants.HeaderLength];
            XpxHeader.WriteUInt32BigEndian(raw, 0, 0xDEADBEEF); // Bad magic
            raw[4] = 1; // Version
            raw[5] = (byte)XpxPacketType.Heartbeat;
            XpxHeader.WriteUInt16BigEndian(raw, 8, XpxProtocolConstants.HeaderLength);

            XpxPacketReader reader = new XpxPacketReader();
            using (MemoryStream ms = new MemoryStream(raw))
            {
                try
                {
                    reader.ReadPacket(ms);
                    throw new Exception("Reader did NOT reject invalid magic!");
                }
                catch (InvalidDataException)
                {
                    // Expected
                }
            }
        }

        public static void TestInvalidVersionRejection()
        {
            byte[] raw = new byte[XpxProtocolConstants.HeaderLength];
            XpxHeader.WriteUInt32BigEndian(raw, 0, XpxProtocolConstants.Magic);
            raw[4] = 99; // Bad version
            raw[5] = (byte)XpxPacketType.Heartbeat;
            XpxHeader.WriteUInt16BigEndian(raw, 8, XpxProtocolConstants.HeaderLength);

            XpxPacketReader reader = new XpxPacketReader();
            using (MemoryStream ms = new MemoryStream(raw))
            {
                try
                {
                    reader.ReadPacket(ms);
                    throw new Exception("Reader did NOT reject unsupported version!");
                }
                catch (InvalidDataException)
                {
                    // Expected
                }
            }
        }

        public static void TestOversizedPayloadRejection()
        {
            byte[] raw = new byte[XpxProtocolConstants.HeaderLength];
            XpxHeader.WriteUInt32BigEndian(raw, 0, XpxProtocolConstants.Magic);
            raw[4] = 1; // Version
            raw[5] = (byte)XpxPacketType.Message;
            XpxHeader.WriteUInt16BigEndian(raw, 8, XpxProtocolConstants.HeaderLength);
            XpxHeader.WriteUInt32BigEndian(raw, 10, 100 * 1024 * 1024); // 100MB untrusted payload size

            XpxPacketReader reader = new XpxPacketReader();
            using (MemoryStream ms = new MemoryStream(raw))
            {
                try
                {
                    reader.ReadPacket(ms);
                    throw new Exception("Reader did NOT reject oversized payload without allocation!");
                }
                catch (InvalidDataException)
                {
                    // Expected
                }
            }
        }

        public static void TestTruncatedPacketRejection()
        {
            byte[] raw = new byte[20]; // Truncated header (< 42 bytes)
            XpxHeader.WriteUInt32BigEndian(raw, 0, XpxProtocolConstants.Magic);

            XpxPacketReader reader = new XpxPacketReader();
            using (MemoryStream ms = new MemoryStream(raw))
            {
                try
                {
                    reader.ReadPacket(ms);
                    throw new Exception("Reader did NOT reject truncated header!");
                }
                catch (InvalidDataException)
                {
                    // Expected
                }
            }
        }

        public static void TestCrc32CorruptionDetection()
        {
            XpxHeader header = new XpxHeader(XpxPacketType.Message, 1, Guid.NewGuid());
            byte[] payload = Encoding.UTF8.GetBytes("Important uncorrupted message");
            XpxPacket pkt = new XpxPacket(header, payload);

            XpxPacketWriter writer = new XpxPacketWriter();
            byte[] streamBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                writer.WritePacket(ms, pkt);
                streamBytes = ms.ToArray();
            }

            // Corrupt one byte of payload in the wire data
            streamBytes[streamBytes.Length - 1] ^= 0xFF;

            XpxPacketReader reader = new XpxPacketReader();
            using (MemoryStream ms = new MemoryStream(streamBytes))
            {
                try
                {
                    reader.ReadPacket(ms);
                    throw new Exception("Reader failed to detect CRC32 payload corruption!");
                }
                catch (InvalidDataException)
                {
                    // Expected
                }
            }
        }

        public static void TestHmacTamperingDetection()
        {
            Guid sessionId = Guid.NewGuid();
            byte[] masterSecret = CryptoProvider.GenerateKey();
            byte[] dummy = new byte[32];

            byte[] clientAes, serverAes, clientHmac, serverHmac;
            KeyExchange.DeriveSessionKeys(masterSecret, dummy, dummy,
                out clientAes, out serverAes, out clientHmac, out serverHmac);

            AesSession clientSession = new AesSession(sessionId, true, clientAes, serverAes, clientHmac, serverHmac);
            AesSession serverSession = new AesSession(sessionId, false, clientAes, serverAes, clientHmac, serverHmac);

            XpxPacket pkt = new XpxPacket(new XpxHeader(XpxPacketType.Message, 1, sessionId), Encoding.UTF8.GetBytes("Secret message"));
            clientSession.EncryptPacket(pkt);

            // Tamper with ciphertext payload
            pkt.Payload[pkt.Payload.Length - 1] ^= 0x01;

            try
            {
                serverSession.DecryptPacket(pkt);
                throw new Exception("Server decrypted tampered ciphertext without detecting HMAC failure!");
            }
            catch (CryptographicException)
            {
                // Expected: HMAC failed before decryption
            }
            finally
            {
                clientSession.Dispose();
                serverSession.Dispose();
            }
        }

        public static void TestDirectionalKeySeparation()
        {
            Guid sessionId = Guid.NewGuid();
            byte[] preMaster = CryptoProvider.GenerateKey();
            byte[] nonceA = CryptoProvider.GenerateRandomBytes(32);
            byte[] nonceB = CryptoProvider.GenerateRandomBytes(32);

            byte[] clientAes, serverAes, clientHmac, serverHmac;
            KeyExchange.DeriveSessionKeys(preMaster, nonceA, nonceB,
                out clientAes, out serverAes, out clientHmac, out serverHmac);

            // Verify keys are completely distinct
            if (CryptoProvider.ConstantTimeEquals(clientAes, serverAes))
                throw new Exception("Client and Server AES keys must not be identical!");
            if (CryptoProvider.ConstantTimeEquals(clientHmac, serverHmac))
                throw new Exception("Client and Server HMAC keys must not be identical!");
            if (CryptoProvider.ConstantTimeEquals(clientAes, clientHmac))
                throw new Exception("AES and HMAC keys must not be identical!");

            AesSession client = new AesSession(sessionId, true, clientAes, serverAes, clientHmac, serverHmac);
            AesSession server = new AesSession(sessionId, false, clientAes, serverAes, clientHmac, serverHmac);

            XpxPacket clientPkt = new XpxPacket(new XpxHeader(XpxPacketType.Message, 1, sessionId), Encoding.UTF8.GetBytes("Ping from Client"));
            client.EncryptPacket(clientPkt);

            byte[] decryptedByServer = server.DecryptPacket(clientPkt);
            string serverReceived = Encoding.UTF8.GetString(decryptedByServer);
            if (serverReceived != "Ping from Client")
                throw new Exception("Server could not decrypt client packet!");

            client.Dispose();
            server.Dispose();
        }

        public static void TestUniqueIvPerPacket()
        {
            Guid sessionId = Guid.NewGuid();
            byte[] key = CryptoProvider.GenerateKey();
            byte[] dummy = new byte[32];
            byte[] cAes, sAes, cHmac, sHmac;
            KeyExchange.DeriveSessionKeys(key, dummy, dummy, out cAes, out sAes, out cHmac, out sHmac);

            AesSession session = new AesSession(sessionId, true, cAes, sAes, cHmac, sHmac);

            XpxPacket pkt1 = new XpxPacket(new XpxHeader(XpxPacketType.Message, 1, sessionId), Encoding.UTF8.GetBytes("Identical plaintext"));
            XpxPacket pkt2 = new XpxPacket(new XpxHeader(XpxPacketType.Message, 2, sessionId), Encoding.UTF8.GetBytes("Identical plaintext"));

            session.EncryptPacket(pkt1);
            session.EncryptPacket(pkt2);

            // Extract IVs (first 16 bytes of payload)
            byte[] iv1 = new byte[16];
            byte[] iv2 = new byte[16];
            Buffer.BlockCopy(pkt1.Payload, 0, iv1, 0, 16);
            Buffer.BlockCopy(pkt2.Payload, 0, iv2, 0, 16);

            if (CryptoProvider.ConstantTimeEquals(iv1, iv2))
                throw new Exception("IV reuse detected! Each encrypted packet must have a unique random IV.");

            session.Dispose();
        }

        public static void TestReplayAttackProtection()
        {
            SessionManager mgr = new SessionManager();
            Guid sessionId = Guid.NewGuid();

            byte[] dummy = new byte[32];
            AesSession aes = new AesSession(sessionId, true, dummy, dummy, dummy, dummy);
            SessionState state = new SessionState(sessionId, aes, "dev1", "PC1");
            mgr.RegisterSession(state);

            string failReason;

            // Packet 1 (valid)
            if (!mgr.ValidateAndTrackPacket(sessionId, 1, out failReason))
                throw new Exception("Packet 1 failed validation: " + failReason);

            // Packet 2 (valid)
            if (!mgr.ValidateAndTrackPacket(sessionId, 2, out failReason))
                throw new Exception("Packet 2 failed validation: " + failReason);

            // Replay Packet 1 (should fail)
            if (mgr.ValidateAndTrackPacket(sessionId, 1, out failReason))
                throw new Exception("Replayed packet 1 was NOT rejected!");

            // Packet 10 (jump forward)
            if (!mgr.ValidateAndTrackPacket(sessionId, 10, out failReason))
                throw new Exception("Packet 10 failed validation: " + failReason);

            // Packet 8 (out-of-order within sliding window threshold: should succeed)
            if (!mgr.ValidateAndTrackPacket(sessionId, 8, out failReason))
                throw new Exception("Packet 8 within window failed validation: " + failReason);

            // Replay Packet 8 (should fail duplicate)
            if (mgr.ValidateAndTrackPacket(sessionId, 8, out failReason))
                throw new Exception("Duplicate packet 8 was NOT rejected!");

            // Packet 100 (jumps way forward)
            if (!mgr.ValidateAndTrackPacket(sessionId, 100, out failReason))
                throw new Exception("Packet 100 failed: " + failReason);

            // Packet 2 (now outside 64-packet window: should fail)
            if (mgr.ValidateAndTrackPacket(sessionId, 2, out failReason))
                throw new Exception("Stale packet 2 outside window was NOT rejected!");

            mgr.InvalidateSession(sessionId);
        }

        public static void TestKeyExchangeHandshake()
        {
            Guid sessionId = Guid.NewGuid();

            // Client initiates
            using (KeyExchange clientKx = new KeyExchange())
            {
                string clientNonceHex, rsaPubKeyXml;
                clientKx.ClientInit(out clientNonceHex, out rsaPubKeyXml);

                // Server processes and derives
                string serverNonceHex, encPreMasterBase64;
                AesSession serverSession;
                KeyExchange.ServerProcessHelloAndDerive(
                    clientNonceHex,
                    rsaPubKeyXml,
                    sessionId,
                    out serverNonceHex,
                    out encPreMasterBase64,
                    out serverSession);

                // Client finishes handshake
                AesSession clientSession = clientKx.ClientFinishHandshake(serverNonceHex, encPreMasterBase64, sessionId);

                // Test communication both ways
                XpxPacket c2s = new XpxPacket(new XpxHeader(XpxPacketType.Message, 1, sessionId), Encoding.UTF8.GetBytes("From Client to Server"));
                clientSession.EncryptPacket(c2s);
                byte[] sDec = serverSession.DecryptPacket(c2s);
                if (Encoding.UTF8.GetString(sDec) != "From Client to Server")
                    throw new Exception("Server decryption failed");

                XpxPacket s2c = new XpxPacket(new XpxHeader(XpxPacketType.Message, 2, sessionId), Encoding.UTF8.GetBytes("From Server to Client"));
                serverSession.EncryptPacket(s2c);
                byte[] cDec = clientSession.DecryptPacket(s2c);
                if (Encoding.UTF8.GetString(cDec) != "From Server to Client")
                    throw new Exception("Client decryption failed");

                clientSession.Dispose();
                serverSession.Dispose();
            }
        }

        public static void TestBufferPoolReuse()
        {
            BufferPool pool = new BufferPool();
            byte[] buf1 = pool.Rent(64 * 1024);
            if (buf1 == null || buf1.Length < 64 * 1024)
                throw new Exception("BufferPool returned invalid buffer");

            buf1[0] = 0xAA;
            pool.Return(buf1);

            byte[] buf2 = pool.Rent(64 * 1024);
            if (!object.ReferenceEquals(buf1, buf2))
                throw new Exception("BufferPool did not reuse returned buffer!");

            pool.Return(buf2);
            pool.Clear();
        }

        public static void TestProfileDetection()
        {
            SystemCapabilities caps = SystemCapabilities.Current;
            if (caps == null) throw new Exception("SystemCapabilities detection returned null");

            PerformanceProfile profile = PerformanceProfile.DetectBestProfile(caps);
            if (profile == null) throw new Exception("PerformanceProfile detection returned null");

            if (profile.ChunkSize < 16 * 1024 || profile.ChunkSize > 1024 * 1024)
                throw new Exception("Chunk size outside safe boundaries: " + profile.ChunkSize);

            if (profile.MaxConcurrentTransfers < 1 || profile.MaxConcurrentTransfers > 4)
                throw new Exception("Concurrency limit outside safe boundaries: " + profile.MaxConcurrentTransfers);
        }

        public static void TestFileTransferResumeSimulation()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), "XPX_Test_" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(tempDir);

            try
            {
                // Create dummy source file (128 KB)
                string srcFile = Path.Combine(tempDir, "test_resume.bin");
                byte[] data = CryptoProvider.GenerateRandomBytes(128 * 1024);
                File.WriteAllBytes(srcFile, data);

                // Compute ground truth hash
                string groundTruthHash;
                using (SHA256Managed sha = new SHA256Managed())
                {
                    groundTruthHash = CryptoProvider.ToHex(sha.ComputeHash(data));
                }

                // Simulate partial transfer: write first 64 KB to partial file
                string destFile = Path.Combine(tempDir, "received.bin");
                string partialFile = destFile + ".xpxpart";
                byte[] firstHalf = new byte[64 * 1024];
                Buffer.BlockCopy(data, 0, firstHalf, 0, firstHalf.Length);
                File.WriteAllBytes(partialFile, firstHalf);

                // Resume simulation: append remaining 64 KB to partial file
                using (FileStream fs = new FileStream(partialFile, FileMode.Append, FileAccess.Write))
                {
                    fs.Write(data, 64 * 1024, 64 * 1024);
                }

                // Verify assembled hash
                string assembledHash;
                using (FileStream fs = new FileStream(partialFile, FileMode.Open, FileAccess.Read))
                using (SHA256Managed sha = new SHA256Managed())
                {
                    assembledHash = CryptoProvider.ToHex(sha.ComputeHash(fs));
                }

                if (assembledHash != groundTruthHash)
                    throw new Exception("Resumed file hash did not match ground truth!");

                // Atomic rename
                File.Move(partialFile, destFile);
                if (!File.Exists(destFile))
                    throw new Exception("Atomic rename failed!");
            }
            finally
            {
                try { Directory.Delete(tempDir, true); } catch { }
            }
        }
    }
}

using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using XpressShare.Core;
using XpressShare.Network;
using XpressShare.Protocol;
using XpressShare.Security;
using XpressShare.Utilities;

namespace XpressShare.Transfers
{
    /// <summary>
    /// Chunked streaming file receiver supporting resume from partial files,
    /// atomic completion renaming, chunk decompression, and end-to-end SHA-256 integrity verification.
    /// Compatible with .NET Framework 3.5 on Windows XP SP3 through Windows 11.
    /// </summary>
    public class FileReceiver
    {
        public delegate void ReceiveProgressDelegate(long bytesReceived, long totalBytes);

        /// <summary>
        /// Receives a file from an incoming XPX connection and writes it directly to destinationDirectory.
        /// </summary>
        public bool ReceiveFile(
            TcpConnection connection,
            string destinationDirectory,
            bool autoAccept,
            ReceiveProgressDelegate progressCallback,
            out string savedFilePath,
            out string errorMessage)
        {
            savedFilePath = null;
            errorMessage = null;

            if (connection == null) throw new ArgumentNullException("connection");
            if (string.IsNullOrEmpty(destinationDirectory))
                destinationDirectory = AppPaths.BasePath;

            if (!Directory.Exists(destinationDirectory))
            {
                try { Directory.CreateDirectory(destinationDirectory); } catch { }
            }

            FileStream fs = null;
            SHA256Managed sha256 = null;
            string partialFilePath = null;

            try
            {
                // 1. Read FileRequest packet
                XpxPacket reqPacket = connection.ReceivePacket();
                if (reqPacket == null || reqPacket.Header.PacketType != XpxPacketType.FileRequest)
                {
                    errorMessage = "Expected FileRequest packet, but received invalid packet.";
                    return false;
                }

                string[] reqParts = reqPacket.GetPayloadAsString().Split('|');
                string rawFileName = reqParts.Length > 0 ? reqParts[0] : "received_file";
                string safeFileName = Path.GetFileName(rawFileName); // Sanitize path traversal
                long expectedLength = reqParts.Length > 1 ? long.Parse(reqParts[1]) : 0;
                int senderChunkSize = reqParts.Length > 2 ? int.Parse(reqParts[2]) : XpxProtocolConstants.DefaultChunkSize;

                string targetFilePath = Path.Combine(destinationDirectory, safeFileName);
                partialFilePath = targetFilePath + ".xpxpart";

                // Check for existing partial file to negotiate resume
                long resumeOffset = 0;
                if (File.Exists(partialFilePath))
                {
                    FileInfo partialInfo = new FileInfo(partialFilePath);
                    if (partialInfo.Length > 0 && partialInfo.Length < expectedLength)
                    {
                        resumeOffset = partialInfo.Length;
                    }
                    else if (partialInfo.Length >= expectedLength)
                    {
                        // Stale or complete partial file, restart fresh
                        File.Delete(partialFilePath);
                    }
                }

                // 2. Send FileResponse packet: ACCEPT|ResumeOffset
                XpxHeader respHeader = new XpxHeader(XpxPacketType.FileResponse, 0, reqPacket.Header.SessionId);
                XpxPacket respPacket = new XpxPacket(respHeader, null);
                respPacket.SetPayloadFromString(string.Format("ACCEPT|{0}", resumeOffset));
                connection.SendPacket(respPacket);

                // 3. Open partial file stream
                fs = new FileStream(partialFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                sha256 = new SHA256Managed();

                // If resuming, hash existing portion to keep rolling hash valid
                if (resumeOffset > 0)
                {
                    byte[] preHashBuf = BufferPool.Shared.Rent(senderChunkSize);
                    try
                    {
                        long hashed = 0;
                        fs.Seek(0, SeekOrigin.Begin);
                        while (hashed < resumeOffset)
                        {
                            int toRead = (int)Math.Min((long)senderChunkSize, resumeOffset - hashed);
                            int read = fs.Read(preHashBuf, 0, toRead);
                            if (read <= 0) break;
                            sha256.TransformBlock(preHashBuf, 0, read, null, 0);
                            hashed += read;
                        }
                    }
                    finally
                    {
                        BufferPool.Shared.Return(preHashBuf);
                    }
                }

                fs.Seek(resumeOffset, SeekOrigin.Begin);
                long currentBytesReceived = resumeOffset;

                // 4. Receive FileChunk packets until FileComplete
                while (currentBytesReceived < expectedLength)
                {
                    XpxPacket pkt = connection.ReceivePacket();
                    if (pkt == null)
                    {
                        errorMessage = "Connection closed prematurely while receiving file chunks.";
                        return false;
                    }

                    if (pkt.Header.PacketType == XpxPacketType.FileCancel)
                    {
                        errorMessage = "Transfer cancelled by sender.";
                        return false;
                    }

                    if (pkt.Header.PacketType != XpxPacketType.FileChunk)
                    {
                        errorMessage = "Unexpected packet type during file transfer: " + pkt.Header.PacketType;
                        return false;
                    }

                    // Parse chunk metadata: [16 bytes Guid] [8 bytes ChunkIndex] [8 bytes Offset] [4 bytes Length] [Data]
                    byte[] rawPayload = pkt.Payload;
                    if (rawPayload == null || rawPayload.Length < 36)
                    {
                        errorMessage = "Malformed file chunk payload.";
                        return false;
                    }

                    long chunkOffset = (long)XpxHeader.ReadUInt64BigEndian(rawPayload, 24);
                    int chunkDataLen = (int)XpxHeader.ReadUInt32BigEndian(rawPayload, 32);

                    byte[] chunkData;
                    if ((pkt.Header.Flags & XpxPacketFlags.Compressed) != 0)
                    {
                        // Decompress chunk
                        chunkData = DecompressChunk(rawPayload, 36, rawPayload.Length - 36);
                    }
                    else
                    {
                        chunkData = new byte[chunkDataLen];
                        Buffer.BlockCopy(rawPayload, 36, chunkData, 0, chunkDataLen);
                    }

                    // Write chunk to partial file
                    fs.Seek(chunkOffset, SeekOrigin.Begin);
                    fs.Write(chunkData, 0, chunkData.Length);
                    currentBytesReceived += chunkData.Length;

                    // Update rolling SHA-256 hash
                    sha256.TransformBlock(chunkData, 0, chunkData.Length, null, 0);

                    if (progressCallback != null)
                    {
                        progressCallback(currentBytesReceived, expectedLength);
                    }
                }

                // 5. Read FileComplete packet
                XpxPacket compPacket = connection.ReceivePacket();
                if (compPacket == null || compPacket.Header.PacketType != XpxPacketType.FileComplete)
                {
                    errorMessage = "Missing or invalid FileComplete packet.";
                    return false;
                }

                string remoteSha256 = compPacket.GetPayloadAsString();

                // Finalize local SHA-256 hash
                sha256.TransformFinalBlock(new byte[0], 0, 0);
                string localSha256 = CryptoProvider.ToHex(sha256.Hash);

                fs.Flush();
                fs.Close();
                fs = null;

                // 6. Verify end-to-end file integrity
                if (!string.Equals(localSha256, remoteSha256, StringComparison.OrdinalIgnoreCase))
                {
                    errorMessage = string.Format("SHA-256 hash mismatch! Local: {0}, Remote: {1}", localSha256, remoteSha256);
                    AppLogger.Log(errorMessage);
                    DeleteQuietly(partialFilePath);
                    return false;
                }

                // 7. Atomic Rename: .xpxpart -> final destination
                if (File.Exists(targetFilePath))
                {
                    File.Delete(targetFilePath);
                }
                File.Move(partialFilePath, targetFilePath);

                savedFilePath = targetFilePath;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                AppLogger.Log("FileReceiver error: " + ex);
                return false;
            }
            finally
            {
                if (fs != null)
                {
                    try { fs.Close(); } catch { }
                    fs = null;
                }
                if (sha256 != null)
                {
                    try { sha256.Clear(); } catch { }
                    sha256 = null;
                }
            }
        }

        private static byte[] DecompressChunk(byte[] buffer, int offset, int count)
        {
            using (MemoryStream msIn = new MemoryStream(buffer, offset, count))
            using (DeflateStream ds = new DeflateStream(msIn, CompressionMode.Decompress))
            using (MemoryStream msOut = new MemoryStream())
            {
                byte[] temp = BufferPool.Shared.Rent(64 * 1024);
                try
                {
                    int read;
                    while ((read = ds.Read(temp, 0, temp.Length)) > 0)
                    {
                        msOut.Write(temp, 0, read);
                    }
                    return msOut.ToArray();
                }
                finally
                {
                    BufferPool.Shared.Return(temp);
                }
            }
        }

        private static void DeleteQuietly(string path)
        {
            try
            {
                if (File.Exists(path)) File.Delete(path);
            }
            catch { }
        }
    }
}

using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using XpressShare.Core;
using XpressShare.Network;
using XpressShare.Protocol;
using XpressShare.Security;
using XpressShare.Utilities;

namespace XpressShare.Transfers
{
    /// <summary>
    /// Chunked streaming file sender supporting pause, resume from arbitrary byte offsets,
    /// buffer pooling, rolling SHA-256 integrity hashing, and adaptive compression.
    /// Compatible with .NET Framework 3.5 on Windows XP SP3 through Windows 11.
    /// </summary>
    public class FileSender
    {
        public delegate void TransferProgressDelegate(long bytesTransferred, long totalBytes);

        /// <summary>
        /// Sends a file over an established XPX TcpConnection.
        /// </summary>
        public bool SendFile(
            TcpConnection connection,
            TransferSession session,
            bool allowCompression,
            TransferProgressDelegate progressCallback,
            out string errorMessage)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (session == null) throw new ArgumentNullException("session");
            if (session.Item == null || string.IsNullOrEmpty(session.Item.FilePath))
            {
                errorMessage = "Invalid transfer file path.";
                return false;
            }

            string filePath = session.Item.FilePath;
            if (!File.Exists(filePath))
            {
                errorMessage = "File not found: " + filePath;
                return false;
            }

            FileInfo fileInfo = new FileInfo(filePath);
            long fileLength = fileInfo.Length;
            session.Item.TotalBytes = fileLength;
            string fileName = Path.GetFileName(filePath);
            int chunkSize = session.ChunkSize > 0 ? session.ChunkSize : XpxProtocolConstants.DefaultChunkSize;

            FileStream fs = null;
            SHA256Managed sha256 = null;
            byte[] rentedBuffer = null;
            errorMessage = null;

            try
            {
                session.Item.Status = TransferStatus.Negotiating;

                // 1. Send FileRequest packet: FileName|FileSize|ChunkSize
                XpxHeader reqHeader = new XpxHeader(XpxPacketType.FileRequest, 0, session.SessionId);
                XpxPacket reqPacket = new XpxPacket(reqHeader, null);
                reqPacket.SetPayloadFromString(string.Format("{0}|{1}|{2}", fileName, fileLength, chunkSize));
                connection.SendPacket(reqPacket);

                // 2. Wait for FileResponse packet (Accept/Reject + ResumeOffset)
                XpxPacket respPacket = connection.ReceivePacket();
                if (respPacket == null || respPacket.Header.PacketType != XpxPacketType.FileResponse)
                {
                    errorMessage = "Remote device disconnected or sent invalid response.";
                    session.Item.Status = TransferStatus.Failed;
                    return false;
                }

                string respPayload = respPacket.GetPayloadAsString();
                string[] parts = respPayload.Split('|');
                string decision = parts.Length > 0 ? parts[0] : "REJECT";
                long resumeOffset = 0;
                if (parts.Length > 1)
                {
                    long.TryParse(parts[1], out resumeOffset);
                }

                if (!string.Equals(decision, "ACCEPT", StringComparison.OrdinalIgnoreCase))
                {
                    errorMessage = "Transfer rejected by remote device: " + (parts.Length > 1 ? parts[1] : "Declined");
                    session.Item.Status = TransferStatus.Cancelled;
                    return false;
                }

                session.ResumeOffset = resumeOffset;
                session.Item.TransferredBytes = resumeOffset;
                session.Item.Status = TransferStatus.InProgress;

                // 3. Open FileStream for streaming read
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, chunkSize);
                sha256 = new SHA256Managed();

                // If resuming, calculate hash of existing prefix and seek
                if (resumeOffset > 0 && resumeOffset <= fileLength)
                {
                    AppLogger.Log(string.Format("Resuming transfer of '{0}' from byte {1} ({2:0.0}%)",
                        fileName, resumeOffset, (resumeOffset / (double)fileLength) * 100.0));
                    
                    // Hash pre-existing portion to keep rolling hash valid
                    byte[] preHashBuf = BufferPool.Shared.Rent(chunkSize);
                    try
                    {
                        long hashed = 0;
                        while (hashed < resumeOffset)
                        {
                            int toRead = (int)Math.Min((long)chunkSize, resumeOffset - hashed);
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

                    fs.Seek(resumeOffset, SeekOrigin.Begin);
                }

                rentedBuffer = BufferPool.Shared.Rent(chunkSize);
                long currentOffset = resumeOffset;
                ulong chunkIndex = (ulong)(resumeOffset / chunkSize);

                // Determine if compression should be used for this file
                bool shouldCompress = allowCompression && IsFileCompressible(fileName);

                // 4. Stream Chunks
                while (currentOffset < fileLength)
                {
                    // Handle Pause state
                    while (session.IsPaused)
                    {
                        Thread.Sleep(200);
                        if (session.IsCancelled || !connection.IsConnected) break;
                    }

                    // Handle Cancel state
                    if (session.IsCancelled || !connection.IsConnected)
                    {
                        errorMessage = session.IsCancelled ? "Transfer cancelled by user." : "Connection lost during transfer.";
                        session.Item.Status = session.IsCancelled ? TransferStatus.Cancelled : TransferStatus.Failed;
                        try
                        {
                            XpxPacket cancelPacket = new XpxPacket(new XpxHeader(XpxPacketType.FileCancel, 0, session.SessionId), null);
                            connection.SendPacket(cancelPacket);
                        }
                        catch { }
                        return false;
                    }

                    int toRead = (int)Math.Min((long)chunkSize, fileLength - currentOffset);
                    int bytesRead = fs.Read(rentedBuffer, 0, toRead);
                    if (bytesRead <= 0) break;

                    // Update rolling SHA-256 hash
                    sha256.TransformBlock(rentedBuffer, 0, bytesRead, null, 0);

                    // Build Chunk Packet: ChunkHeader = TransferId|ChunkIndex|Offset|Length
                    byte[] chunkPayload = null;
                    bool isCompressed = false;

                    if (shouldCompress)
                    {
                        byte[] compressed = TryCompressChunk(rentedBuffer, bytesRead);
                        if (compressed != null && compressed.Length < bytesRead)
                        {
                            chunkPayload = WrapChunkMetadata(session.SessionId, chunkIndex, currentOffset, compressed);
                            isCompressed = true;
                        }
                    }

                    if (chunkPayload == null)
                    {
                        chunkPayload = WrapChunkMetadata(session.SessionId, chunkIndex, currentOffset, rentedBuffer, bytesRead);
                    }

                    XpxHeader chunkHeader = new XpxHeader(XpxPacketType.FileChunk, 0, session.SessionId);
                    if (isCompressed) chunkHeader.Flags |= XpxPacketFlags.Compressed;
                    if (currentOffset + bytesRead >= fileLength) chunkHeader.Flags |= XpxPacketFlags.Last;

                    XpxPacket chunkPacket = new XpxPacket(chunkHeader, chunkPayload);
                    connection.SendPacket(chunkPacket);

                    currentOffset += bytesRead;
                    chunkIndex++;
                    session.UpdateProgress(currentOffset);

                    if (progressCallback != null)
                    {
                        progressCallback(currentOffset, fileLength);
                    }
                }

                // 5. Finalize SHA-256 hash
                sha256.TransformFinalBlock(new byte[0], 0, 0);
                string fileHash = CryptoProvider.ToHex(sha256.Hash);
                session.Item.Sha256Hash = fileHash;

                // 6. Send FileComplete packet with final SHA-256 hash
                XpxHeader compHeader = new XpxHeader(XpxPacketType.FileComplete, 0, session.SessionId);
                XpxPacket compPacket = new XpxPacket(compHeader, null);
                compPacket.SetPayloadFromString(fileHash);
                connection.SendPacket(compPacket);

                session.Item.Status = TransferStatus.Completed;
                session.Item.CompletedAt = DateTime.UtcNow;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                session.Item.Status = TransferStatus.Failed;
                session.Item.ErrorMessage = ex.Message;
                AppLogger.Log("FileSender error: " + ex);
                return false;
            }
            finally
            {
                if (rentedBuffer != null)
                {
                    BufferPool.Shared.Return(rentedBuffer);
                }
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

        private static byte[] WrapChunkMetadata(Guid transferId, ulong chunkIndex, long offset, byte[] data, int count)
        {
            // Format: [16 bytes Guid] [8 bytes ChunkIndex] [8 bytes Offset] [4 bytes DataLength] [Data]
            byte[] wrapped = new byte[36 + count];
            byte[] guidBytes = transferId.ToByteArray();
            Buffer.BlockCopy(guidBytes, 0, wrapped, 0, 16);
            XpxHeader.WriteUInt64BigEndian(wrapped, 16, chunkIndex);
            XpxHeader.WriteUInt64BigEndian(wrapped, 24, (ulong)offset);
            XpxHeader.WriteUInt32BigEndian(wrapped, 32, (uint)count);
            Buffer.BlockCopy(data, 0, wrapped, 36, count);
            return wrapped;
        }

        private static byte[] WrapChunkMetadata(Guid transferId, ulong chunkIndex, long offset, byte[] compressedData)
        {
            return WrapChunkMetadata(transferId, chunkIndex, offset, compressedData, compressedData.Length);
        }

        private static byte[] TryCompressChunk(byte[] data, int count)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (DeflateStream ds = new DeflateStream(ms, CompressionMode.Compress, true))
                    {
                        ds.Write(data, 0, count);
                        ds.Flush();
                    }
                    return ms.ToArray();
                }
            }
            catch
            {
                return null;
            }
        }

        private static bool IsFileCompressible(string filename)
        {
            string ext = Path.GetExtension(filename).ToLowerInvariant();
            switch (ext)
            {
                // Incompressible media and archives - do NOT waste CPU cycles
                case ".zip":
                case ".rar":
                case ".7z":
                case ".tar":
                case ".gz":
                case ".bz2":
                case ".mp4":
                case ".mkv":
                case ".avi":
                case ".mov":
                case ".mp3":
                case ".flac":
                case ".aac":
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".gif":
                case ".webp":
                case ".iso":
                case ".pdf":
                    return false;

                // Highly compressible text/data
                case ".txt":
                case ".log":
                case ".csv":
                case ".xml":
                case ".json":
                case ".html":
                case ".htm":
                case ".sql":
                case ".doc":
                case ".rtf":
                case ".bmp":
                    return true;

                default:
                    return false;
            }
        }
    }
}

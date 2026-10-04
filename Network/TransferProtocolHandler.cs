using System;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using XpressShare.Core;

namespace XpressShare.Network
{
    public static class TransferProtocolHandler
    {
        public const int ChunkSize = 65536; // 64KB

        public static bool SendMessage(NetworkStream stream, ProtocolMessage message)
        {
            if (stream == null || message == null)
                return false;

            try
            {
                byte[] data = message.Serialize();
                byte[] lengthBytes = BitConverter.GetBytes(data.Length);
                stream.Write(lengthBytes, 0, 4);
                stream.Write(data, 0, data.Length);
                stream.Flush();
                return true;
            }
            catch (Exception ex)
            {
                AppLogger.Log("TransferProtocolHandler.SendMessage error: " + ex.Message);
                return false;
            }
        }

        public static ProtocolMessage ReadMessage(NetworkStream stream)
        {
            if (stream == null)
                return null;

            try
            {
                byte[] lengthBytes = new byte[4];
                if (!ReadExact(stream, lengthBytes, 0, 4))
                    return null;

                int length = BitConverter.ToInt32(lengthBytes, 0);
                if (length <= 0 || length > 10 * 1024 * 1024) // Sanity limit: 10MB
                    return null;

                byte[] data = new byte[length];
                if (!ReadExact(stream, data, 0, length))
                    return null;

                return ProtocolMessage.Deserialize(data);
            }
            catch (Exception ex)
            {
                AppLogger.Log("TransferProtocolHandler.ReadMessage error: " + ex.Message);
                return null;
            }
        }

        public static bool ReadExact(NetworkStream stream, byte[] buffer, int offset, int count)
        {
            if (stream == null || buffer == null || count < 0)
                return false;

            int totalRead = 0;
            while (totalRead < count)
            {
                int bytesRead = stream.Read(buffer, offset + totalRead, count - totalRead);
                if (bytesRead <= 0)
                    return false; // EOF or connection closed
                totalRead += bytesRead;
            }
            return true;
        }

        public static bool SendFile(TcpClient client, string filePath, Action<long> progressCallback)
        {
            return SendFile(client, filePath, string.Empty, string.Empty, progressCallback);
        }

        public static bool SendFile(TcpClient client, string filePath, string localDeviceId, string localDeviceName, Action<long> progressCallback)
        {
            if (client == null || !File.Exists(filePath))
                return false;

            NetworkStream stream = null;
            FileStream fs = null;
            SHA1 sha1 = null;

            try
            {
                stream = client.GetStream();
                FileInfo fileInfo = new FileInfo(filePath);

                // Send transfer start message with file metadata
                ProtocolMessage startMsg = new ProtocolMessage
                {
                    Type = ProtocolMessageType.TransferStart,
                    SenderId = localDeviceId ?? string.Empty,
                    SenderName = localDeviceName ?? string.Empty,
                    Payload = Path.GetFileName(filePath) + "|" + fileInfo.Length
                };

                if (!SendMessage(stream, startMsg))
                    return false;

                // Wait for receiver to accept or reject transfer
                ProtocolMessage response = ReadMessage(stream);
                if (response == null || response.Type == ProtocolMessageType.TransferReject)
                {
                    AppLogger.Log("Transfer was rejected by recipient or connection dropped.");
                    return false;
                }

                if (response.Type != ProtocolMessageType.TransferAccept)
                {
                    AppLogger.Log("Unexpected response from receiver: " + response.Type);
                    return false;
                }

                // Send file data in 64KB chunks
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                sha1 = SHA1.Create();

                byte[] buffer = new byte[ChunkSize];
                long totalSent = 0;
                int bytesRead;

                while ((bytesRead = fs.Read(buffer, 0, ChunkSize)) > 0)
                {
                    stream.Write(buffer, 0, bytesRead);
                    totalSent += bytesRead;
                    sha1.TransformBlock(buffer, 0, bytesRead, null, 0);

                    if (progressCallback != null)
                    {
                        progressCallback(totalSent);
                    }
                }

                sha1.TransformFinalBlock(new byte[0], 0, 0);
                byte[] hash = sha1.Hash;
                stream.Flush();

                // Send completion message with hash
                ProtocolMessage completeMsg = new ProtocolMessage
                {
                    Type = ProtocolMessageType.TransferComplete,
                    Payload = Convert.ToBase64String(hash)
                };

                if (!SendMessage(stream, completeMsg))
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                AppLogger.Log("TransferProtocolHandler.SendFile error: " + ex.Message);
                return false;
            }
            finally
            {
                if (fs != null)
                {
                    try { fs.Dispose(); } catch { }
                }
                if (sha1 != null)
                {
                    try { sha1.Clear(); } catch { }
                }
            }
        }

        public static bool ReceiveFile(TcpClient client, string destinationPath, Action<long> progressCallback)
        {
            if (client == null || string.IsNullOrEmpty(destinationPath))
                return false;

            try
            {
                NetworkStream stream = client.GetStream();

                // Read TransferStart message
                ProtocolMessage startMsg = ReadMessage(stream);
                if (startMsg == null || startMsg.Type != ProtocolMessageType.TransferStart)
                    return false;

                string[] parts = startMsg.Payload.Split(new char[] { '|' }, StringSplitOptions.None);
                string fileName = parts.Length > 0 ? parts[0] : "file";
                long expectedSize = parts.Length > 1 ? long.Parse(parts[1]) : 0;

                // Send accept message
                ProtocolMessage acceptMsg = new ProtocolMessage
                {
                    Type = ProtocolMessageType.TransferAccept,
                    Payload = "OK"
                };
                if (!SendMessage(stream, acceptMsg))
                    return false;

                return ReceiveFilePayload(stream, destinationPath, fileName, expectedSize, progressCallback);
            }
            catch (Exception ex)
            {
                AppLogger.Log("TransferProtocolHandler.ReceiveFile error: " + ex.Message);
                return false;
            }
        }

        public static bool ReceiveFilePayload(NetworkStream stream, string destinationPath, string fileName, long expectedSize, Action<long> progressCallback)
        {
            if (stream == null || string.IsNullOrEmpty(destinationPath))
                return false;

            string targetFilePath = destinationPath;
            if (Directory.Exists(destinationPath))
            {
                targetFilePath = Path.Combine(destinationPath, fileName);
            }
            else
            {
                string dir = Path.GetDirectoryName(destinationPath);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
            }

            FileStream fs = null;
            SHA1 sha1 = null;

            try
            {
                fs = new FileStream(targetFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
                sha1 = SHA1.Create();

                byte[] buffer = new byte[ChunkSize];
                long totalReceived = 0;

                while (totalReceived < expectedSize)
                {
                    int toRead = (int)Math.Min((long)ChunkSize, expectedSize - totalReceived);
                    int bytesRead = stream.Read(buffer, 0, toRead);
                    if (bytesRead <= 0)
                    {
                        throw new IOException("Premature end of stream while receiving file data.");
                    }

                    fs.Write(buffer, 0, bytesRead);
                    totalReceived += bytesRead;
                    sha1.TransformBlock(buffer, 0, bytesRead, null, 0);

                    if (progressCallback != null)
                    {
                        progressCallback(totalReceived);
                    }
                }

                sha1.TransformFinalBlock(new byte[0], 0, 0);
                byte[] calculatedHash = sha1.Hash;

                // Close file stream before reading complete message
                fs.Flush();
                fs.Close();
                fs = null;

                // Read completion message
                ProtocolMessage completeMsg = ReadMessage(stream);
                if (completeMsg == null || completeMsg.Type != ProtocolMessageType.TransferComplete)
                {
                    AppLogger.Log("Missing or invalid TransferComplete message.");
                    DeleteFileQuietly(targetFilePath);
                    return false;
                }

                byte[] remoteHash = Convert.FromBase64String(completeMsg.Payload);
                if (!ConstantTimeEquals(calculatedHash, remoteHash))
                {
                    AppLogger.Log("Hash mismatch for received file: " + targetFilePath);
                    DeleteFileQuietly(targetFilePath);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                AppLogger.Log("TransferProtocolHandler.ReceiveFilePayload error: " + ex.Message);
                if (fs != null)
                {
                    try { fs.Close(); } catch { }
                }
                DeleteFileQuietly(targetFilePath);
                return false;
            }
            finally
            {
                if (fs != null)
                {
                    try { fs.Dispose(); } catch { }
                }
                if (sha1 != null)
                {
                    try { sha1.Clear(); } catch { }
                }
            }
        }

        private static void DeleteFileQuietly(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);
            }
            catch
            {
            }
        }

        private static bool ConstantTimeEquals(byte[] a, byte[] b)
        {
            if (a == null || b == null || a.Length != b.Length)
                return false;

            int result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result |= a[i] ^ b[i];
            }

            return result == 0;
        }
    }
}

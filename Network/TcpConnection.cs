using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using XpressShare.Protocol;
using XpressShare.Security;

namespace XpressShare.Network
{
    public enum ConnectionState
    {
        Disconnected,
        Connecting,
        Connected,
        Reconnecting,
        Failed
    }

    /// <summary>
    /// Encapsulates a raw TCP socket connection for the XPX/1 protocol.
    /// Handles timeouts, keep-alive, socket error categorization, deterministic cleanup,
    /// and optional authenticated encryption via AesSession.
    /// Compatible with .NET Framework 3.5 on Windows XP SP3 through Windows 11.
    /// </summary>
    public class TcpConnection : IDisposable
    {
        private Socket _socket;
        private NetworkStream _stream;
        private readonly XpxPacketReader _reader;
        private readonly XpxPacketWriter _writer;
        private bool _disposed;
        private readonly object _syncLock = new object();

        public ConnectionState State { get; private set; }
        public string RemoteIp { get; private set; }
        public int RemotePort { get; private set; }
        public AesSession CryptoSession { get; set; }
        public ulong NextPacketId { get; set; }

        public event EventHandler<EventArgs> Disconnected;

        public bool IsConnected
        {
            get
            {
                if (_disposed || _socket == null) return false;
                try
                {
                    return _socket.Connected && State == ConnectionState.Connected;
                }
                catch
                {
                    return false;
                }
            }
        }

        public TcpConnection()
        {
            _reader = new XpxPacketReader();
            _writer = new XpxPacketWriter();
            State = ConnectionState.Disconnected;
            NextPacketId = 1;
        }

        public TcpConnection(Socket socket)
            : this()
        {
            if (socket == null) throw new ArgumentNullException("socket");
            ConfigureSocket(socket);
            _socket = socket;
            _stream = new NetworkStream(_socket, true);
            State = ConnectionState.Connected;

            try
            {
                IPEndPoint ep = _socket.RemoteEndPoint as IPEndPoint;
                if (ep != null)
                {
                    RemoteIp = ep.Address.ToString();
                    RemotePort = ep.Port;
                }
            }
            catch { }
        }

        public void Connect(string host, int port, int timeoutMs)
        {
            if (string.IsNullOrEmpty(host)) throw new ArgumentNullException("host");
            if (port <= 0 || port > 65535) throw new ArgumentOutOfRangeException("port");

            lock (_syncLock)
            {
                if (IsConnected)
                    Close();

                State = ConnectionState.Connecting;
                RemoteIp = host;
                RemotePort = port;

                try
                {
                    IPAddress ip;
                    if (!IPAddress.TryParse(host, out ip))
                    {
                        IPHostEntry entry = Dns.GetHostEntry(host);
                        if (entry.AddressList.Length == 0)
                            throw new SocketException((int)SocketError.HostNotFound);
                        ip = entry.AddressList[0];
                    }

                    IPEndPoint endpoint = new IPEndPoint(ip, port);
                    _socket = new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    ConfigureSocket(_socket);

                    // Connect with timeout compatible with .NET 3.5
                    IAsyncResult ar = _socket.BeginConnect(endpoint, null, null);
                    bool success = ar.AsyncWaitHandle.WaitOne(timeoutMs > 0 ? timeoutMs : 15000, false);
                    if (!success)
                    {
                        _socket.Close();
                        State = ConnectionState.Failed;
                        throw new SocketException((int)SocketError.TimedOut);
                    }

                    _socket.EndConnect(ar);
                    _stream = new NetworkStream(_socket, true);
                    State = ConnectionState.Connected;
                }
                catch (SocketException sex)
                {
                    State = ConnectionState.Failed;
                    HandleSocketException(sex);
                    throw;
                }
                catch (Exception)
                {
                    State = ConnectionState.Failed;
                    Close();
                    throw;
                }
            }
        }

        private static void ConfigureSocket(Socket s)
        {
            s.NoDelay = true; // Disable Nagle's algorithm for low latency
            s.ReceiveTimeout = XpxProtocolConstants.DefaultSocketTimeoutMs;
            s.SendTimeout = XpxProtocolConstants.DefaultSocketTimeoutMs;
            s.LingerState = new LingerOption(true, 2);
        }

        /// <summary>
        /// Sends an XPX packet over the network.
        /// If CryptoSession is active, automatically encrypts and attaches HMAC.
        /// </summary>
        public void SendPacket(XpxPacket packet)
        {
            if (packet == null) throw new ArgumentNullException("packet");

            lock (_syncLock)
            {
                CheckConnected();

                try
                {
                    if (packet.Header.PacketId == 0)
                    {
                        packet.Header.PacketId = NextPacketId++;
                    }

                    if (CryptoSession != null)
                    {
                        packet.Header.SessionId = CryptoSession.SessionId;
                        CryptoSession.EncryptPacket(packet);
                    }

                    _writer.WritePacket(_stream, packet);
                }
                catch (SocketException sex)
                {
                    HandleSocketException(sex);
                    throw;
                }
                catch (IOException ioex)
                {
                    HandleIoException(ioex);
                    throw;
                }
            }
        }

        /// <summary>
        /// Receives the next XPX packet.
        /// If CryptoSession is active and packet is encrypted, verifies HMAC and decrypts payload.
        /// Returns null on clean EOF.
        /// </summary>
        public XpxPacket ReceivePacket()
        {
            lock (_syncLock)
            {
                CheckConnected();
            }

            try
            {
                XpxPacket packet = _reader.ReadPacket(_stream);
                if (packet == null)
                {
                    // Clean EOF
                    Close();
                    return null;
                }

                if (CryptoSession != null && packet.IsEncrypted)
                {
                    byte[] decryptedPayload = CryptoSession.DecryptPacket(packet);
                    packet.Payload = decryptedPayload;
                    packet.Header.PayloadLength = (uint)(decryptedPayload != null ? decryptedPayload.Length : 0);
                }

                return packet;
            }
            catch (SocketException sex)
            {
                HandleSocketException(sex);
                throw;
            }
            catch (IOException ioex)
            {
                HandleIoException(ioex);
                throw;
            }
        }

        private void CheckConnected()
        {
            if (_disposed || _stream == null || _socket == null || !IsConnected)
            {
                throw new InvalidOperationException("TCP Connection is not open.");
            }
        }

        public void HandleSocketException(SocketException sex)
        {
            switch (sex.SocketErrorCode)
            {
                case SocketError.ConnectionReset:
                case SocketError.ConnectionAborted:
                case SocketError.Shutdown:
                case SocketError.Disconnecting:
                case SocketError.TimedOut:
                case SocketError.HostDown:
                case SocketError.HostUnreachable:
                case SocketError.NetworkDown:
                case SocketError.NetworkUnreachable:
                case SocketError.ConnectionRefused:
                    Close();
                    break;
                default:
                    Close();
                    break;
            }
        }

        private void HandleIoException(IOException ioex)
        {
            SocketException sex = ioex.InnerException as SocketException;
            if (sex != null)
            {
                HandleSocketException(sex);
            }
            else
            {
                Close();
            }
        }

        public void Close()
        {
            lock (_syncLock)
            {
                if (State != ConnectionState.Disconnected)
                {
                    State = ConnectionState.Disconnected;

                    if (_stream != null)
                    {
                        try { _stream.Close(); } catch { }
                        _stream = null;
                    }

                    if (_socket != null)
                    {
                        try
                        {
                            if (_socket.Connected)
                                _socket.Shutdown(SocketShutdown.Both);
                        }
                        catch { }
                        try { _socket.Close(); } catch { }
                        _socket = null;
                    }

                    OnDisconnected();
                }
            }
        }

        private void OnDisconnected()
        {
            if (Disconnected != null)
            {
                Disconnected(this, EventArgs.Empty);
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                Close();
                if (CryptoSession != null)
                {
                    CryptoSession.Dispose();
                    CryptoSession = null;
                }
            }
        }
    }
}

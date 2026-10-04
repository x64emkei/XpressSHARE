using System;
using System.Collections.Generic;

namespace XpressShare.Security
{
    public class SessionState
    {
        public Guid SessionId { get; set; }
        public AesSession AesSession { get; set; }
        public string RemoteDeviceId { get; set; }
        public string RemoteDeviceName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastActivity { get; set; }

        // Replay protection: tracks largest received sequence ID and bitmap window for sliding window
        public ulong MaxReceivedPacketId { get; set; }
        public ulong ReplayWindowBitmap { get; set; } // 64-packet window

        public SessionState(Guid sessionId, AesSession aesSession, string remoteDeviceId, string remoteDeviceName)
        {
            SessionId = sessionId;
            AesSession = aesSession;
            RemoteDeviceId = remoteDeviceId;
            RemoteDeviceName = remoteDeviceName;
            CreatedAt = DateTime.UtcNow;
            LastActivity = DateTime.UtcNow;
            MaxReceivedPacketId = 0;
            ReplayWindowBitmap = 0;
        }
    }

    /// <summary>
    /// Thread-safe manager for XPX secure sessions.
    /// Enforces session expiration, monotonic packet sequencing, and sliding window replay protection.
    /// </summary>
    public class SessionManager
    {
        private static readonly SessionManager _instance = new SessionManager();
        public static SessionManager Instance { get { return _instance; } }

        private readonly Dictionary<Guid, SessionState> _activeSessions = new Dictionary<Guid, SessionState>();
        private readonly object _lock = new object();

        // 1 hour maximum idle session timeout
        private static readonly TimeSpan SessionIdleTimeout = TimeSpan.FromHours(1);

        public void RegisterSession(SessionState state)
        {
            if (state == null) throw new ArgumentNullException("state");

            lock (_lock)
            {
                CleanupExpiredSessionsInternal();
                _activeSessions[state.SessionId] = state;
            }
        }

        public SessionState GetSession(Guid sessionId)
        {
            lock (_lock)
            {
                SessionState state;
                if (_activeSessions.TryGetValue(sessionId, out state))
                {
                    if (DateTime.UtcNow - state.LastActivity > SessionIdleTimeout)
                    {
                        _activeSessions.Remove(sessionId);
                        state.AesSession.Dispose();
                        return null;
                    }
                    state.LastActivity = DateTime.UtcNow;
                    return state;
                }
                return null;
            }
        }

        public void InvalidateSession(Guid sessionId)
        {
            lock (_lock)
            {
                SessionState state;
                if (_activeSessions.TryGetValue(sessionId, out state))
                {
                    _activeSessions.Remove(sessionId);
                    if (state.AesSession != null)
                    {
                        state.AesSession.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// Validates packet against replay attacks using a 64-packet sliding window.
        /// Rejects duplicates, stale packets falling behind the window, or invalid sessions.
        /// </summary>
        public bool ValidateAndTrackPacket(Guid sessionId, ulong packetId, out string failureReason)
        {
            lock (_lock)
            {
                SessionState state;
                if (!_activeSessions.TryGetValue(sessionId, out state))
                {
                    failureReason = "Unknown or expired session ID: " + sessionId;
                    return false;
                }

                state.LastActivity = DateTime.UtcNow;

                // First packet in session
                if (state.MaxReceivedPacketId == 0 && packetId > 0)
                {
                    state.MaxReceivedPacketId = packetId;
                    state.ReplayWindowBitmap = 1;
                    failureReason = null;
                    return true;
                }

                // Packet is newer than largest seen
                if (packetId > state.MaxReceivedPacketId)
                {
                    ulong diff = packetId - state.MaxReceivedPacketId;
                    if (diff >= 64)
                    {
                        state.ReplayWindowBitmap = 1;
                    }
                    else
                    {
                        state.ReplayWindowBitmap <<= (int)diff;
                        state.ReplayWindowBitmap |= 1;
                    }
                    state.MaxReceivedPacketId = packetId;
                    failureReason = null;
                    return true;
                }

                // Packet is older than or within window
                ulong age = state.MaxReceivedPacketId - packetId;
                if (age >= 64)
                {
                    failureReason = string.Format("Replay attack detected: Packet ID {0} is older than sliding window threshold.", packetId);
                    return false;
                }

                ulong bit = 1UL << (int)age;
                if ((state.ReplayWindowBitmap & bit) != 0)
                {
                    failureReason = string.Format("Duplicate/Replayed packet detected: Packet ID {0} already processed.", packetId);
                    return false;
                }

                // Mark packet received in bitmap
                state.ReplayWindowBitmap |= bit;
                failureReason = null;
                return true;
            }
        }

        private void CleanupExpiredSessionsInternal()
        {
            DateTime now = DateTime.UtcNow;
            List<Guid> expired = new List<Guid>();

            foreach (KeyValuePair<Guid, SessionState> kvp in _activeSessions)
            {
                if (now - kvp.Value.LastActivity > SessionIdleTimeout)
                {
                    expired.Add(kvp.Key);
                }
            }

            foreach (Guid id in expired)
            {
                SessionState st = _activeSessions[id];
                _activeSessions.Remove(id);
                if (st.AesSession != null)
                {
                    st.AesSession.Dispose();
                }
            }
        }
    }
}

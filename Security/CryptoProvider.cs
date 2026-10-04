using System;
using System.Security.Cryptography;

namespace XpressShare.Security
{
    /// <summary>
    /// Cryptographic helper providing cryptographically secure random values and timing-attack-safe comparisons.
    /// Compatible with .NET Framework 3.5 on Windows XP SP3 through Windows 11.
    /// </summary>
    public static class CryptoProvider
    {
        private static readonly RNGCryptoServiceProvider Rng = new RNGCryptoServiceProvider();

        /// <summary>
        /// Generates cryptographically secure random bytes using RNGCryptoServiceProvider.
        /// </summary>
        public static byte[] GenerateRandomBytes(int length)
        {
            if (length <= 0) throw new ArgumentOutOfRangeException("length", "Length must be greater than zero.");
            byte[] bytes = new byte[length];
            Rng.GetBytes(bytes);
            return bytes;
        }

        /// <summary>
        /// Generates a 16-byte unpredictable IV for AES-CBC.
        /// </summary>
        public static byte[] GenerateIv()
        {
            return GenerateRandomBytes(16);
        }

        /// <summary>
        /// Generates a 32-byte (256-bit) cryptographically strong key or secret.
        /// </summary>
        public static byte[] GenerateKey()
        {
            return GenerateRandomBytes(32);
        }

        /// <summary>
        /// Constant-time byte array comparison to prevent timing attacks.
        /// </summary>
        public static bool ConstantTimeEquals(byte[] a, byte[] b)
        {
            if (a == null || b == null || a.Length != b.Length)
                return false;

            int diff = 0;
            for (int i = 0; i < a.Length; i++)
            {
                diff |= a[i] ^ b[i];
            }
            return diff == 0;
        }

        /// <summary>
        /// Converts byte array to lowercase hexadecimal string.
        /// </summary>
        public static string ToHex(byte[] data)
        {
            if (data == null) return string.Empty;
            char[] c = new char[data.Length * 2];
            int b;
            for (int i = 0; i < data.Length; i++)
            {
                b = data[i] >> 4;
                c[i * 2] = (char)(55 + b + (((b - 10) >> 31) & -7));
                b = data[i] & 0xF;
                c[i * 2 + 1] = (char)(55 + b + (((b - 10) >> 31) & -7));
            }
            return new string(c).ToLowerInvariant();
        }

        /// <summary>
        /// Converts hexadecimal string to byte array.
        /// </summary>
        public static byte[] FromHex(string hex)
        {
            if (string.IsNullOrEmpty(hex)) return new byte[0];
            if ((hex.Length % 2) != 0)
                throw new ArgumentException("Hex string must have an even length.", "hex");

            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return bytes;
        }
    }
}

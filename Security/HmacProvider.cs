using System;
using System.Security.Cryptography;

namespace XpressShare.Security
{
    /// <summary>
    /// Computes and verifies HMAC-SHA256 authentication tags.
    /// Used in Encrypt-then-MAC construction to protect packet integrity and authenticity.
    /// </summary>
    public static class HmacProvider
    {
        /// <summary>
        /// Computes 32-byte HMAC-SHA256 over data using the provided key.
        /// </summary>
        public static byte[] ComputeHmac(byte[] key, byte[] data)
        {
            if (key == null) throw new ArgumentNullException("key");
            if (data == null) throw new ArgumentNullException("data");

            using (HMACSHA256 hmac = new HMACSHA256(key))
            {
                return hmac.ComputeHash(data);
            }
        }

        /// <summary>
        /// Computes 32-byte HMAC-SHA256 over two byte array segments (e.g. Header + Ciphertext).
        /// </summary>
        public static byte[] ComputeHmac(byte[] key, byte[] part1, byte[] part2)
        {
            if (key == null) throw new ArgumentNullException("key");

            using (HMACSHA256 hmac = new HMACSHA256(key))
            {
                if (part1 != null && part1.Length > 0)
                {
                    if (part2 != null && part2.Length > 0)
                    {
                        hmac.TransformBlock(part1, 0, part1.Length, null, 0);
                        hmac.TransformFinalBlock(part2, 0, part2.Length);
                        return hmac.Hash;
                    }
                    return hmac.ComputeHash(part1);
                }
                if (part2 != null && part2.Length > 0)
                {
                    return hmac.ComputeHash(part2);
                }
                return hmac.ComputeHash(new byte[0]);
            }
        }

        /// <summary>
        /// Verifies whether the provided HMAC matches the expected HMAC in constant time.
        /// </summary>
        public static bool VerifyHmac(byte[] key, byte[] data, byte[] expectedHmac)
        {
            if (key == null || data == null || expectedHmac == null || expectedHmac.Length != 32)
                return false;

            byte[] actual = ComputeHmac(key, data);
            return CryptoProvider.ConstantTimeEquals(actual, expectedHmac);
        }

        /// <summary>
        /// Verifies whether the provided HMAC matches the expected HMAC over two parts in constant time.
        /// </summary>
        public static bool VerifyHmac(byte[] key, byte[] part1, byte[] part2, byte[] expectedHmac)
        {
            if (key == null || expectedHmac == null || expectedHmac.Length != 32)
                return false;

            byte[] actual = ComputeHmac(key, part1, part2);
            return CryptoProvider.ConstantTimeEquals(actual, expectedHmac);
        }
    }
}

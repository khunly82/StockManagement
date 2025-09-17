using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace StockManagement.Infrastructure.Security
{
    public static class HashUtils
    {
        private const int SaltSize = 16; // 128 bits
        private const int HashSize = 32; // 256 bits
        private const int DegreeOfParallelism = 8; // Number of threads to use
        private const int Iterations = 4; // Number of iterations
        private const int MemorySize = 1024 * 1024; // 1 GB

        public static byte[] HashPassword(string password)
        {
            // Générer un sel aléatoire
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Générer le hash
            return HashPassword(password, salt);
        }


        public static byte[] HashPassword(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = DegreeOfParallelism,
                Iterations = Iterations,
                MemorySize = MemorySize
            };

            byte[] hash = argon2.GetBytes(HashSize);

            byte[] hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            return hashBytes;

        }

        public static bool VerifyPassword(string password, byte[] hashedPassword)
        {
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashedPassword, 0, salt, 0, SaltSize);

            byte[] storedHash = new byte[HashSize];
            Array.Copy(hashedPassword, SaltSize, storedHash, 0, HashSize);

            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = DegreeOfParallelism,
                Iterations = Iterations,
                MemorySize = MemorySize
            };

            byte[] newHash = argon2.GetBytes(HashSize);

            return CryptographicOperations.FixedTimeEquals(newHash, storedHash);
        }

    }
}

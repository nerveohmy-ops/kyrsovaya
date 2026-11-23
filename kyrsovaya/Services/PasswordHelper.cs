using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace kyrsovaya.Services
{
    /// <summary>
    /// Хеширование паролей, проверка надёжности и генерация нового пароля.
    /// </summary>
    public static class PasswordHelper
    {
        public const int MinLength = 6;

        /// <summary>SHA-256 пароля в виде hex-строки (64 символа).</summary>
        public static string Hash(string password)
        {
            using (var sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                return string.Concat(bytes.Select(b => b.ToString("X2")));
            }
        }

        public static bool Verify(string password, string hash)
        {
            return string.Equals(Hash(password), hash, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Возвращает текст ошибки или null, если пароль подходит:
        /// не меньше 6 символов, есть буквы и цифры.
        /// </summary>
        public static string CheckStrength(string password)
        {
            if (string.IsNullOrEmpty(password))
                return "Введите пароль";
            if (password.Length < MinLength)
                return "Пароль должен быть не короче " + MinLength + " символов";
            if (!password.Any(char.IsLetter))
                return "В пароле должна быть хотя бы одна буква";
            if (!password.Any(char.IsDigit))
                return "В пароле должна быть хотя бы одна цифра";
            return null;
        }

        /// <summary>Случайный пароль, который проходит CheckStrength.</summary>
        public static string Generate()
        {
            const string letters = "abcdefghijkmnpqrstuvwxyz";
            const string digits = "23456789";

            var chars = new char[8];
            using (var rng = new RNGCryptoServiceProvider())
            {
                // Первые два символа гарантируют наличие буквы и цифры
                chars[0] = Pick(rng, letters);
                chars[1] = Pick(rng, digits);
                for (int i = 2; i < chars.Length; i++)
                {
                    chars[i] = Pick(rng, letters + digits);
                }
                // Перемешиваем (Фишер — Йетс)
                for (int i = chars.Length - 1; i > 0; i--)
                {
                    int j = Next(rng, i + 1);
                    char tmp = chars[i];
                    chars[i] = chars[j];
                    chars[j] = tmp;
                }
            }
            return new string(chars);
        }

        private static char Pick(RNGCryptoServiceProvider rng, string source)
        {
            return source[Next(rng, source.Length)];
        }

        private static int Next(RNGCryptoServiceProvider rng, int max)
        {
            var bytes = new byte[4];
            rng.GetBytes(bytes);
            return (int)(BitConverter.ToUInt32(bytes, 0) % (uint)max);
        }
    }
}

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
        public const int MinLength = 12;

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
        /// Возвращает текст ошибки или null, если пароль надёжный:
        /// не меньше 12 символов, есть буквы, цифры и спецсимволы.
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
            if (!password.Any(c => !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c)))
                return "В пароле должен быть хотя бы один спецсимвол (например ! # $ %)";
            return null;
        }

        /// <summary>Случайный пароль, который проходит CheckStrength.</summary>
        public static string Generate()
        {
            const string letters = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";
            const string digits = "23456789";
            const string symbols = "!#$%&*?";

            var chars = new char[14];
            using (var rng = new RNGCryptoServiceProvider())
            {
                // Первые три символа гарантируют наличие буквы, цифры и спецсимвола
                chars[0] = Pick(rng, letters);
                chars[1] = Pick(rng, digits);
                chars[2] = Pick(rng, symbols);
                for (int i = 3; i < chars.Length; i++)
                {
                    chars[i] = Pick(rng, letters + digits + symbols);
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

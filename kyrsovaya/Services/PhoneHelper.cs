using System.Linq;

namespace kyrsovaya.Services
{
    /// <summary>
    /// Номер телефона в базе хранится как 10 цифр (без +7).
    /// </summary>
    public static class PhoneHelper
    {
        /// <summary>Достаёт 10 цифр из любой записи номера. Если это не номер, вернёт null.</summary>
        public static string Normalize(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return null;

            string digits = new string(text.Where(char.IsDigit).ToArray());
            if (digits.Length == 11 && (digits[0] == '7' || digits[0] == '8'))
                digits = digits.Substring(1);

            return digits.Length == 10 ? digits : null;
        }

        /// <summary>9001112233 -> +7 (900) 111-22-33</summary>
        public static string Format(string digits)
        {
            if (digits == null || digits.Length != 10) return digits;
            return string.Format("+7 ({0}) {1}-{2}-{3}",
                digits.Substring(0, 3), digits.Substring(3, 3),
                digits.Substring(6, 2), digits.Substring(8, 2));
        }
    }
}

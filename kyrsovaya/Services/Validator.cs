using System.Text.RegularExpressions;

namespace kyrsovaya.Services
{
    /// <summary>
    /// Проверки полей ввода. Каждый метод возвращает текст ошибки или null, если всё верно.
    /// </summary>
    public static class Validator
    {
        private static readonly Regex NameRegex = new Regex(@"^[A-Za-zА-Яа-яЁё\- ]{2,50}$");
        private static readonly Regex LoginRegex = new Regex(@"^[A-Za-z0-9_.]{4,30}$");
        private static readonly Regex EmailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        public static string Name(string value, string fieldTitle)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "Заполните поле «" + fieldTitle + "»";
            if (!NameRegex.IsMatch(value.Trim()))
                return "«" + fieldTitle + "»: только буквы, от 2 до 50 символов";
            return null;
        }

        public static string Login(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "Введите логин";
            if (!LoginRegex.IsMatch(value))
                return "Логин: 4–30 символов, латинские буквы, цифры, _ и точка";
            return null;
        }

        public static string Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "Введите email";
            if (!value.Contains("@"))
                return "В email должен быть символ @";
            if (value.Length > 100 || !EmailRegex.IsMatch(value))
                return "Email указан неверно, пример: name@mail.ru";
            return null;
        }

        /// <summary>Проверка номера телефона. Нужны ровно 10 цифр после +7.</summary>
        public static string Phone(string digits)
        {
            if (PhoneHelper.Normalize(digits) == null)
                return "Введите телефон полностью: +7 (900) 123-45-67";
            return null;
        }

        public static string PasswordRepeat(string password, string repeat)
        {
            if (string.IsNullOrEmpty(repeat))
                return "Повторите пароль";
            if (password != repeat)
                return "Пароли не совпадают";
            return null;
        }
    }
}

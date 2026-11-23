namespace kyrsovaya.Models
{
    /// <summary>
    /// Идентификаторы ролей. Должны совпадать с таблицей Roles в базе данных.
    /// </summary>
    public static class RoleIds
    {
        public const int Admin = 1;
        public const int Scientist = 2;
        public const int Visitor = 3;
        public const int Guide = 4;
    }

    /// <summary>
    /// Данные пользователя приложения.
    /// </summary>
    public class UserInfo
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }   // 10 цифр без кода страны
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public string FullName
        {
            get { return LastName + " " + FirstName; }
        }

        public bool IsAdmin
        {
            get { return RoleId == RoleIds.Admin; }
        }

        public bool IsGuide
        {
            get { return RoleId == RoleIds.Guide; }
        }

        /// <summary>Может ли пользователь добавлять и менять данные о видах и наблюдениях.</summary>
        public bool CanEditData
        {
            get { return RoleId == RoleIds.Admin || RoleId == RoleIds.Scientist; }
        }
    }

    /// <summary>
    /// Хранит пользователя, который сейчас вошёл в систему.
    /// </summary>
    public static class Session
    {
        public static UserInfo CurrentUser { get; set; }
    }
}

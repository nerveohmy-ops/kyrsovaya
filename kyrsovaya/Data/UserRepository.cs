using System;
using System.Data;
using kyrsovaya.Models;
using kyrsovaya.Services;

namespace kyrsovaya.Data
{
    /// <summary>
    /// Запросы к таблице Users.
    /// </summary>
    public class UserRepository
    {
        private const string SelectUser =
            "SELECT u.Id, u.Login, u.PasswordHash, u.LastName, u.FirstName, u.Email, u.Phone, " +
            "u.RoleId, r.Name AS RoleName " +
            "FROM Users u JOIN Roles r ON r.Id = u.RoleId ";

        /// <summary>Ищет пользователя по логину, email или телефону.</summary>
        public UserInfo FindByIdentifier(string identifier)
        {
            string phone = PhoneHelper.Normalize(identifier) ?? "";
            DataTable table = Db.Query(
                SelectUser + "WHERE u.Login = @id OR u.Email = @id OR u.Phone = @phone",
                Db.Param("@id", identifier),
                Db.Param("@phone", phone));

            return table.Rows.Count == 0 ? null : ToUser(table.Rows[0]);
        }

        public UserInfo GetById(int id)
        {
            DataTable table = Db.Query(SelectUser + "WHERE u.Id = @id", Db.Param("@id", id));
            return table.Rows.Count == 0 ? null : ToUser(table.Rows[0]);
        }

        // excludeId нужен при редактировании профиля, чтобы не считать дублем самого себя
        public bool LoginExists(string login, int excludeId = 0)
        {
            return Exists("Login", login, excludeId);
        }

        public bool EmailExists(string email, int excludeId = 0)
        {
            return Exists("Email", email, excludeId);
        }

        public bool PhoneExists(string phone, int excludeId = 0)
        {
            return Exists("Phone", phone, excludeId);
        }

        private bool Exists(string column, string value, int excludeId)
        {
            // Имя столбца передаётся только из этого класса, поэтому подстановка безопасна
            int count = (int)Db.Scalar(
                "SELECT COUNT(*) FROM Users WHERE " + column + " = @value AND Id <> @id",
                Db.Param("@value", value),
                Db.Param("@id", excludeId));
            return count > 0;
        }

        public void Add(UserInfo user)
        {
            Db.Execute(
                "INSERT INTO Users (Login, PasswordHash, LastName, FirstName, Email, Phone, RoleId) " +
                "VALUES (@login, @hash, @last, @first, @email, @phone, @role)",
                Db.Param("@login", user.Login),
                Db.Param("@hash", user.PasswordHash),
                Db.Param("@last", user.LastName),
                Db.Param("@first", user.FirstName),
                Db.Param("@email", user.Email),
                Db.Param("@phone", user.Phone),
                Db.Param("@role", user.RoleId));
        }

        public void UpdateProfile(UserInfo user)
        {
            Db.Execute(
                "UPDATE Users SET LastName = @last, FirstName = @first, Email = @email, Phone = @phone " +
                "WHERE Id = @id",
                Db.Param("@last", user.LastName),
                Db.Param("@first", user.FirstName),
                Db.Param("@email", user.Email),
                Db.Param("@phone", user.Phone),
                Db.Param("@id", user.Id));
        }

        public void UpdatePassword(int userId, string passwordHash)
        {
            Db.Execute("UPDATE Users SET PasswordHash = @hash WHERE Id = @id",
                Db.Param("@hash", passwordHash),
                Db.Param("@id", userId));
        }

        public void UpdateRole(int userId, int roleId)
        {
            Db.Execute("UPDATE Users SET RoleId = @role WHERE Id = @id",
                Db.Param("@role", roleId),
                Db.Param("@id", userId));
        }

        public void Delete(int userId)
        {
            Db.Execute("DELETE FROM Users WHERE Id = @id", Db.Param("@id", userId));
        }

        /// <summary>Список всех пользователей для администратора.</summary>
        public DataTable GetAll()
        {
            return Db.Query(
                "SELECT u.Id, u.Login, u.LastName + N' ' + u.FirstName AS FullName, u.Email, u.Phone, " +
                "u.RoleId, r.Name AS RoleName " +
                "FROM Users u JOIN Roles r ON r.Id = u.RoleId ORDER BY u.LastName, u.FirstName");
        }

        public DataTable GetRoles()
        {
            return Db.Query("SELECT Id, Name FROM Roles ORDER BY Id");
        }

        private static UserInfo ToUser(DataRow row)
        {
            return new UserInfo
            {
                Id = (int)row["Id"],
                Login = (string)row["Login"],
                PasswordHash = ((string)row["PasswordHash"]).Trim(),
                LastName = (string)row["LastName"],
                FirstName = (string)row["FirstName"],
                Email = (string)row["Email"],
                Phone = ((string)row["Phone"]).Trim(),
                RoleId = (int)row["RoleId"],
                RoleName = (string)row["RoleName"]
            };
        }
    }
}

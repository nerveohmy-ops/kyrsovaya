using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace kyrsovaya.Data
{
    /// <summary>
    /// Работа с базой данных: подключение, создание БД при первом запуске
    /// и короткие методы для выполнения запросов.
    /// </summary>
    public static class Db
    {
        private const string DatabaseName = "NationalParkDB";
        private const string ExcursionsMarker = "-- === EXCURSIONS_START ===";

        private static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["ParkDb"].ConnectionString; }
        }

        /// <summary>
        /// Если базы данных ещё нет, создаёт её из встроенного SQL-скрипта.
        /// Если база уже есть со старой версией схемы — добавляет таблицы экскурсий.
        /// </summary>
        public static void EnsureCreated()
        {
            var builder = new SqlConnectionStringBuilder(ConnectionString);
            builder.InitialCatalog = "master";

            using (var conn = new SqlConnection(builder.ConnectionString))
            {
                conn.Open();

                var check = new SqlCommand("SELECT DB_ID(@name)", conn);
                check.Parameters.AddWithValue("@name", DatabaseName);
                if (check.ExecuteScalar() == DBNull.Value)
                {
                    ExecuteBatches(conn, ReadScript());
                    return;
                }
            }

            // База уже существует — проверим, появились ли таблицы экскурсий, роль гида и пароли 2026
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                ExecuteBatches(conn,
                    "IF NOT EXISTS (SELECT 1 FROM Roles WHERE Id = 4) " +
                    "    INSERT INTO Roles (Id, Name) VALUES (4, N'Гид');\n" +
                    "IF NOT EXISTS (SELECT 1 FROM Users WHERE Login = N'guide1') " +
                    "    INSERT INTO Users (Login, PasswordHash, LastName, FirstName, Email, Phone, RoleId) " +
                    "    VALUES (N'guide1', CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'guide!2026park'), 2), N'Ковалёв', N'Артём', N'kovalev@grinpich.ru', '9003334451', 4);\n" +
                    "IF NOT EXISTS (SELECT 1 FROM Users WHERE Login = N'guide2') " +
                    "    INSERT INTO Users (Login, PasswordHash, LastName, FirstName, Email, Phone, RoleId) " +
                    "    VALUES (N'guide2', CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'guide!2026park'), 2), N'Белова', N'Дарья', N'belova@grinpich.ru', '9003334452', 4);\n" +
                    "UPDATE Users SET PasswordHash = CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'admin!2026park'), 2) " +
                    "    WHERE PasswordHash IN (CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'Admin2024!Park'), 2), CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'admin2026'), 2));\n" +
                    "UPDATE Users SET PasswordHash = CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'park!2026demo'), 2) " +
                    "    WHERE PasswordHash IN (CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'Park2024!Demo'), 2), CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'park2026'), 2));\n" +
                    "UPDATE Users SET PasswordHash = CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'guide!2026park'), 2) " +
                    "    WHERE PasswordHash = CONVERT(CHAR(64), HASHBYTES('SHA2_256', 'guide2026'), 2);");

                var checkTable = new SqlCommand("SELECT OBJECT_ID(N'dbo.Excursions', N'U')", conn);
                if (checkTable.ExecuteScalar() == DBNull.Value)
                {
                    string script = ReadScript();
                    int index = script.IndexOf(ExcursionsMarker, StringComparison.Ordinal);
                    if (index >= 0)
                    {
                        ExecuteBatches(conn, script.Substring(index));
                    }
                }
            }
        }

        private static void ExecuteBatches(SqlConnection conn, string script)
        {
            // Скрипт делится на пакеты по строке GO
            string[] batches = Regex.Split(script, @"^\s*GO\s*$",
                RegexOptions.Multiline | RegexOptions.IgnoreCase);

            foreach (string batch in batches)
            {
                if (string.IsNullOrWhiteSpace(batch)) continue;
                using (var cmd = new SqlCommand(batch, conn))
                {
                    cmd.CommandTimeout = 120;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static string ReadScript()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string resourceName = asm.GetManifestResourceNames()
                .First(n => n.EndsWith(".sql", StringComparison.OrdinalIgnoreCase));

            using (var stream = asm.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>Создаёт параметр запроса; null превращается в DBNull.</summary>
        public static SqlParameter Param(string name, object value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }

        /// <summary>Выполняет SELECT и возвращает таблицу.</summary>
        public static DataTable Query(string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddRange(parameters);
                var table = new DataTable();
                new SqlDataAdapter(cmd).Fill(table);
                return table;
            }
        }

        /// <summary>Выполняет INSERT / UPDATE / DELETE.</summary>
        public static int Execute(string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>Возвращает первое значение первой строки (например, COUNT или новый Id).</summary>
        public static object Scalar(string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>Проверяет, что ошибка вызвана внешним ключом (нельзя удалить связанную запись).</summary>
        public static bool IsForeignKeyError(SqlException ex)
        {
            return ex.Number == 547;
        }
    }
}

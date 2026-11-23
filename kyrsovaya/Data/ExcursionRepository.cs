using System;
using System.Data;
using System.Data.SqlClient;

namespace kyrsovaya.Data
{
    /// <summary>
    /// Запросы к таблицам Excursions и ExcursionBookings.
    /// </summary>
    public class ExcursionRepository
    {
        /// <summary>
        /// Список экскурсий с поиском и фильтром.
        /// filterMode: 0 — все, 1 — открытые, 2 — закрытые, 3 — мои записи.
        /// </summary>
        public DataTable GetAll(string search, int filterMode, int currentUserId)
        {
            return Db.Query(
                "SELECT e.Id, e.Title, z.Name AS ZoneName, e.ExcursionDate, " +
                "e.GuideId, g.LastName + N' ' + g.FirstName AS GuideName, " +
                "(SELECT COUNT(*) FROM ExcursionBookings b WHERE b.ExcursionId = e.Id) AS BookedCount, " +
                "e.MaxParticipants, e.IsOpen, " +
                "CASE WHEN e.IsOpen = 1 THEN N'Открыта' ELSE N'Закрыта' END AS StatusText, " +
                "CASE WHEN EXISTS (SELECT 1 FROM ExcursionBookings b WHERE b.ExcursionId = e.Id AND b.UserId = @userId) " +
                "     THEN 1 ELSE 0 END AS IsBooked, " +
                "CASE WHEN EXISTS (SELECT 1 FROM ExcursionBookings b WHERE b.ExcursionId = e.Id AND b.UserId = @userId) " +
                "     THEN N'Вы записаны' ELSE N'—' END AS MyBooking, " +
                "e.Description " +
                "FROM Excursions e " +
                "JOIN Zones z ON z.Id = e.ZoneId " +
                "JOIN Users g ON g.Id = e.GuideId " +
                "WHERE (@search = N'' OR e.Title LIKE N'%' + @search + N'%' OR z.Name LIKE N'%' + @search + N'%') " +
                "AND (@mode = 0 " +
                "     OR (@mode = 1 AND e.IsOpen = 1) " +
                "     OR (@mode = 2 AND e.IsOpen = 0) " +
                "     OR (@mode = 3 AND EXISTS (SELECT 1 FROM ExcursionBookings b WHERE b.ExcursionId = e.Id AND b.UserId = @userId))) " +
                "ORDER BY e.IsOpen DESC, e.ExcursionDate ASC",
                Db.Param("@search", search),
                Db.Param("@mode", filterMode),
                Db.Param("@userId", currentUserId));
        }

        public DataRow GetById(int id)
        {
            DataTable table = Db.Query("SELECT * FROM Excursions WHERE Id = @id", Db.Param("@id", id));
            return table.Rows.Count == 0 ? null : table.Rows[0];
        }

        public int GetBookedCount(int excursionId)
        {
            return (int)Db.Scalar(
                "SELECT COUNT(*) FROM ExcursionBookings WHERE ExcursionId = @id",
                Db.Param("@id", excursionId));
        }

        /// <summary>Гиды и научные сотрудники, которые могут вести экскурсии.</summary>
        public DataTable GetGuides()
        {
            return Db.Query(
                "SELECT u.Id, u.LastName + N' ' + u.FirstName + N' (' + r.Name + N')' AS FullName " +
                "FROM Users u JOIN Roles r ON r.Id = u.RoleId " +
                "WHERE u.RoleId IN (4, 2, 1) " +
                "ORDER BY CASE WHEN u.RoleId = 4 THEN 0 ELSE 1 END, u.LastName, u.FirstName");
        }

        /// <summary>Назначает гида на выбранную экскурсию.</summary>
        public void SetGuide(int id, int guideId)
        {
            Db.Execute("UPDATE Excursions SET GuideId = @guide WHERE Id = @id",
                Db.Param("@guide", guideId),
                Db.Param("@id", id));
        }

        public void Add(string title, int zoneId, int guideId, DateTime excursionDate,
            int maxParticipants, bool isOpen, string description)
        {
            Db.Execute(
                "INSERT INTO Excursions (Title, ZoneId, GuideId, ExcursionDate, MaxParticipants, IsOpen, Description) " +
                "VALUES (@title, @zone, @guide, @date, @max, @open, @desc)",
                Db.Param("@title", title),
                Db.Param("@zone", zoneId),
                Db.Param("@guide", guideId),
                Db.Param("@date", excursionDate),
                Db.Param("@max", maxParticipants),
                Db.Param("@open", isOpen),
                Db.Param("@desc", description));
        }

        public void Update(int id, string title, int zoneId, int guideId, DateTime excursionDate,
            int maxParticipants, bool isOpen, string description)
        {
            Db.Execute(
                "UPDATE Excursions SET Title = @title, ZoneId = @zone, GuideId = @guide, " +
                "ExcursionDate = @date, MaxParticipants = @max, IsOpen = @open, Description = @desc " +
                "WHERE Id = @id",
                Db.Param("@title", title),
                Db.Param("@zone", zoneId),
                Db.Param("@guide", guideId),
                Db.Param("@date", excursionDate),
                Db.Param("@max", maxParticipants),
                Db.Param("@open", isOpen),
                Db.Param("@desc", description),
                Db.Param("@id", id));
        }

        /// <summary>Открывает или закрывает экскурсию для записи.</summary>
        public void SetOpen(int id, bool isOpen)
        {
            Db.Execute("UPDATE Excursions SET IsOpen = @open WHERE Id = @id",
                Db.Param("@open", isOpen),
                Db.Param("@id", id));
        }

        public void Delete(int id)
        {
            Db.Execute("DELETE FROM Excursions WHERE Id = @id", Db.Param("@id", id));
        }

        /// <summary>
        /// Записывает клиента на экскурсию. Возвращает null при успехе или текст ошибки.
        /// </summary>
        public string Book(int excursionId, int userId)
        {
            DataRow row = GetById(excursionId);
            if (row == null) return "Экскурсия не найдена.";
            if (!(bool)row["IsOpen"]) return "Запись на эту экскурсию закрыта научным сотрудником.";
            if ((DateTime)row["ExcursionDate"] < DateTime.Now) return "Экскурсия уже прошла.";

            int already = (int)Db.Scalar(
                "SELECT COUNT(*) FROM ExcursionBookings WHERE ExcursionId = @exc AND UserId = @usr",
                Db.Param("@exc", excursionId),
                Db.Param("@usr", userId));
            if (already > 0) return "Вы уже записаны на эту экскурсию.";

            int booked = GetBookedCount(excursionId);
            int max = (int)row["MaxParticipants"];
            if (booked >= max) return "На эту экскурсию не осталось свободных мест.";

            try
            {
                Db.Execute(
                    "INSERT INTO ExcursionBookings (ExcursionId, UserId) VALUES (@exc, @usr)",
                    Db.Param("@exc", excursionId),
                    Db.Param("@usr", userId));
                return null;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                    return "Вы уже записаны на эту экскурсию.";
                throw;
            }
        }

        public void CancelBooking(int excursionId, int userId)
        {
            Db.Execute(
                "DELETE FROM ExcursionBookings WHERE ExcursionId = @exc AND UserId = @usr",
                Db.Param("@exc", excursionId),
                Db.Param("@usr", userId));
        }

        public DataTable GetParticipants(int excursionId)
        {
            return Db.Query(
                "SELECT b.Id, u.Login, u.LastName + N' ' + u.FirstName AS FullName, " +
                "u.Phone, u.Email, b.BookedAt " +
                "FROM ExcursionBookings b " +
                "JOIN Users u ON u.Id = b.UserId " +
                "WHERE b.ExcursionId = @exc " +
                "ORDER BY b.BookedAt",
                Db.Param("@exc", excursionId));
        }

        public void RemoveBooking(int bookingId)
        {
            Db.Execute("DELETE FROM ExcursionBookings WHERE Id = @id", Db.Param("@id", bookingId));
        }

        public int CountOpen()
        {
            return (int)Db.Scalar("SELECT COUNT(*) FROM Excursions WHERE IsOpen = 1");
        }
    }
}

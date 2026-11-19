using System;
using System.Data;

namespace kyrsovaya.Data
{
    /// <summary>
    /// Запросы к таблице Observations.
    /// </summary>
    public class ObservationRepository
    {
        public DataTable GetAll(string search, int zoneId)
        {
            return Db.Query(
                "SELECT o.Id, o.ObservationDate, sp.Name AS SpeciesName, z.Name AS ZoneName, " +
                "o.Quantity, u.LastName + N' ' + u.FirstName AS Author, o.Notes " +
                "FROM Observations o " +
                "JOIN Species sp ON sp.Id = o.SpeciesId " +
                "JOIN Zones z ON z.Id = o.ZoneId " +
                "JOIN Users u ON u.Id = o.UserId " +
                "WHERE (@search = N'' OR sp.Name LIKE N'%' + @search + N'%' OR o.Notes LIKE N'%' + @search + N'%') " +
                "AND (@zone = 0 OR o.ZoneId = @zone) " +
                "ORDER BY o.ObservationDate DESC, o.Id DESC",
                Db.Param("@search", search),
                Db.Param("@zone", zoneId));
        }

        public DataRow GetById(int id)
        {
            DataTable table = Db.Query("SELECT * FROM Observations WHERE Id = @id", Db.Param("@id", id));
            return table.Rows.Count == 0 ? null : table.Rows[0];
        }

        public void Add(int speciesId, int zoneId, int userId, DateTime date, int quantity, string notes)
        {
            Db.Execute(
                "INSERT INTO Observations (SpeciesId, ZoneId, UserId, ObservationDate, Quantity, Notes) " +
                "VALUES (@species, @zone, @user, @date, @qty, @notes)",
                Db.Param("@species", speciesId), Db.Param("@zone", zoneId), Db.Param("@user", userId),
                Db.Param("@date", date.Date), Db.Param("@qty", quantity), Db.Param("@notes", notes));
        }

        public void Update(int id, int speciesId, int zoneId, DateTime date, int quantity, string notes)
        {
            Db.Execute(
                "UPDATE Observations SET SpeciesId = @species, ZoneId = @zone, ObservationDate = @date, " +
                "Quantity = @qty, Notes = @notes WHERE Id = @id",
                Db.Param("@species", speciesId), Db.Param("@zone", zoneId),
                Db.Param("@date", date.Date), Db.Param("@qty", quantity), Db.Param("@notes", notes),
                Db.Param("@id", id));
        }

        public void Delete(int id)
        {
            Db.Execute("DELETE FROM Observations WHERE Id = @id", Db.Param("@id", id));
        }

        public int CountAll()
        {
            return (int)Db.Scalar("SELECT COUNT(*) FROM Observations");
        }
    }
}

using System.Data;

namespace kyrsovaya.Data
{
    /// <summary>
    /// Запросы к таблицам Species и ConservationStatuses.
    /// </summary>
    public class SpeciesRepository
    {
        /// <summary>
        /// Список видов с фильтрами. Пустая строка / 0 означают «без фильтра».
        /// </summary>
        public DataTable GetAll(string search, string kind, int statusId)
        {
            return Db.Query(
                "SELECT s.Id, s.Name, s.LatinName, s.Kind, st.Code AS StatusCode, " +
                "st.Code + N' — ' + st.Name AS Status, s.Population, s.Description " +
                "FROM Species s JOIN ConservationStatuses st ON st.Id = s.StatusId " +
                "WHERE (@search = N'' OR s.Name LIKE N'%' + @search + N'%' OR s.LatinName LIKE N'%' + @search + N'%') " +
                "AND (@kind = N'' OR s.Kind = @kind) " +
                "AND (@status = 0 OR s.StatusId = @status) " +
                "ORDER BY s.Name",
                Db.Param("@search", search),
                Db.Param("@kind", kind),
                Db.Param("@status", statusId));
        }

        /// <summary>Короткий список (Id, Name) для выпадающих списков.</summary>
        public DataTable GetNames()
        {
            return Db.Query("SELECT Id, Name FROM Species ORDER BY Name");
        }

        public DataRow GetById(int id)
        {
            DataTable table = Db.Query("SELECT * FROM Species WHERE Id = @id", Db.Param("@id", id));
            return table.Rows.Count == 0 ? null : table.Rows[0];
        }

        public bool NameExists(string name, int excludeId)
        {
            int count = (int)Db.Scalar("SELECT COUNT(*) FROM Species WHERE Name = @name AND Id <> @id",
                Db.Param("@name", name), Db.Param("@id", excludeId));
            return count > 0;
        }

        public void Add(string name, string latin, string kind, int statusId, int population, string description)
        {
            Db.Execute(
                "INSERT INTO Species (Name, LatinName, Kind, StatusId, Population, Description) " +
                "VALUES (@name, @latin, @kind, @status, @pop, @desc)",
                Db.Param("@name", name), Db.Param("@latin", latin), Db.Param("@kind", kind),
                Db.Param("@status", statusId), Db.Param("@pop", population), Db.Param("@desc", description));
        }

        public void Update(int id, string name, string latin, string kind, int statusId, int population, string description)
        {
            Db.Execute(
                "UPDATE Species SET Name = @name, LatinName = @latin, Kind = @kind, StatusId = @status, " +
                "Population = @pop, Description = @desc WHERE Id = @id",
                Db.Param("@name", name), Db.Param("@latin", latin), Db.Param("@kind", kind),
                Db.Param("@status", statusId), Db.Param("@pop", population), Db.Param("@desc", description),
                Db.Param("@id", id));
        }

        public void Delete(int id)
        {
            Db.Execute("DELETE FROM Species WHERE Id = @id", Db.Param("@id", id));
        }

        public DataTable GetStatuses()
        {
            return Db.Query("SELECT Id, Code + N' — ' + Name AS Name FROM ConservationStatuses ORDER BY Id");
        }

        // ----- Статистика для главной формы -----

        public int CountAll()
        {
            return (int)Db.Scalar("SELECT COUNT(*) FROM Species");
        }

        /// <summary>Виды под угрозой: CR (2), EN (3) и VU (4).</summary>
        public int CountThreatened()
        {
            return (int)Db.Scalar("SELECT COUNT(*) FROM Species WHERE StatusId IN (2, 3, 4)");
        }
    }
}

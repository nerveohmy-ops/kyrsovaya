using System.Data;

namespace kyrsovaya.Data
{
    /// <summary>
    /// Запросы к таблице Zones (участки национального парка).
    /// </summary>
    public class ZoneRepository
    {
        public DataTable GetAll()
        {
            return Db.Query("SELECT Id, Name, AreaHa, Description FROM Zones ORDER BY Name");
        }

        public DataRow GetById(int id)
        {
            DataTable table = Db.Query("SELECT * FROM Zones WHERE Id = @id", Db.Param("@id", id));
            return table.Rows.Count == 0 ? null : table.Rows[0];
        }

        public bool NameExists(string name, int excludeId)
        {
            int count = (int)Db.Scalar("SELECT COUNT(*) FROM Zones WHERE Name = @name AND Id <> @id",
                Db.Param("@name", name), Db.Param("@id", excludeId));
            return count > 0;
        }

        public void Add(string name, decimal area, string description)
        {
            Db.Execute("INSERT INTO Zones (Name, AreaHa, Description) VALUES (@name, @area, @desc)",
                Db.Param("@name", name), Db.Param("@area", area), Db.Param("@desc", description));
        }

        public void Update(int id, string name, decimal area, string description)
        {
            Db.Execute("UPDATE Zones SET Name = @name, AreaHa = @area, Description = @desc WHERE Id = @id",
                Db.Param("@name", name), Db.Param("@area", area), Db.Param("@desc", description),
                Db.Param("@id", id));
        }

        public void Delete(int id)
        {
            Db.Execute("DELETE FROM Zones WHERE Id = @id", Db.Param("@id", id));
        }
    }
}

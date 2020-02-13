using BandScheduler.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BandScheduler.Services
{
    public class PerformerSQLService : SQLService<Performer>, IService<Performer>
    {
        protected override string Table => "Performer";

        public PerformerSQLService(IDatabaseSettings settings) : base(settings) { }

        protected override Performer ToModel(SqlDataReader data)
        {
            return new Performer
            {
                Id          = (int)data["Id"],
                Name        = (string)data["Name"],
                Description = (string)data["Description"]
            };
        }

        public IEnumerable<Performer> Get() => ExecuteQuery($"SELECT * FROM {Table}");

        public Performer Get(int id) => ExecuteQuery($"SELECT * FROM {Table} WHERE Id = {id}").FirstOrDefault();

        public void Create(Performer model)
        {
            ExecuteQuery(
                $"INSERT INTO {Table} (Name, Description) " +
                $"VALUES ('{model.Name}', '{model.Description}')"
            );
        }

        public void Update(int id, Performer model)
        {
            ExecuteQuery(
                $"UPDATE {Table} " +
                $"SET Name = '{model.Name}', Description = '{model.Description}' " +
                $"WHERE Id = {id};"
            );
        }

        public void Delete(int id)
        {
            ExecuteQuery(
                $"DELETE FROM {Table} " +
                $"WHERE Id = {id}"
            );
        }
    }
}

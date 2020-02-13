using BandScheduler.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BandScheduler.Services
{
    public class StageSQLService : SQLService<Stage>, IService<Stage>
    {
        protected override string Table => "Stage";

        public StageSQLService(IDatabaseSettings settings) : base(settings) { }

        protected override Stage ToModel(SqlDataReader data)
        {
            return new Stage
            {
                Id      = (int)data["Id"],
                Name    = (string)data["Name"]
            };
        }

        public IEnumerable<Stage> Get() => ExecuteQuery($"SELECT * FROM {Table}");

        public Stage Get(int id) => ExecuteQuery($"SELECT * FROM {Table} WHERE Id = {id}").FirstOrDefault();

        public void Create(Stage model)
        {
            ExecuteQuery(
                $"INSERT INTO {Table} (Name) " +
                $"VALUES ('{model.Name}')"
            );
        }

        public void Update(int id, Stage model)
        {
            ExecuteQuery(
                $"UPDATE {Table} " +
                $"SET Name = '{model.Name}' " +
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

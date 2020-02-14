using BandScheduler.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BandScheduler.Services
{
    public class PerformanceSQLService : SQLService<Performance>, IPerformanceService
    {
        protected override string Table => "Performance";

        public PerformanceSQLService(IDatabaseSettings settings) : base(settings) 
        {

        }

        protected override Performance ToModel(SqlDataReader data)
        {
            return new Performance
            {
                Id              = (int)data["id"],
                PerformerId     = (int)data["PerformerId"],
                StageId         = (int)data["StageId"],
                StartDateTime   = (DateTime)data["StartDateTime"],
                EndDateTime     = (DateTime)data["EndDateTime"]
            };
        }

        public IEnumerable<Performance> GetByStage(int id) => ExecuteQuery($"SELECT * FROM {Table} WHERE StageId = {id}");

        public IEnumerable<Performance> Get() => ExecuteQuery($"SELECT * FROM {Table}");

        public Performance Get(int id) => ExecuteQuery($"SELECT * FROM {Table} WHERE Id = {id}").FirstOrDefault();

        public void Create(Performance model)
        {
            ExecuteQuery(
                $"INSERT INTO {Table} (PerformerId, StageId, StartDateTime, EndDateTime) " +
                $"VALUES ({model.PerformerId}, {model.StageId}, '{model.StartDateTime}', '{model.EndDateTime}')"
            );
        }

        public void Create(Performance model, string startDateString, string endDateString)
        {
            model.StartDateTime = DateTime.Parse(startDateString);
            model.EndDateTime = DateTime.Parse(endDateString);

            ExecuteQuery(
                $"INSERT INTO {Table} (PerformerId, StageId, StartDateTime, EndDateTime) " +
                $"VALUES ({model.PerformerId}, {model.StageId}, '{model.StartDateTime.ToString("yyyy-MM-dd HH:mm:ss")}', '{model.EndDateTime.ToString("yyyy-MM-dd HH:mm:ss")}')"
            );
        }

        public void Update(int id, Performance model)
        {
            ExecuteQuery(
                $"UPDATE {Table} " +
                $"SET PerformerId = {model.PerformerId}, StageId = {model.StageId}, StartDateTime = '{model.StartDateTime}', EndDateTime = '{model.EndDateTime}' " +
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

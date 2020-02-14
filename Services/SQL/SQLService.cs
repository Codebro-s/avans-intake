using BandScheduler.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BandScheduler.Services
{
    public abstract class SQLService<T>
    {
        private readonly string _connectionString;

        public SQLService(IDatabaseSettings settings)
        {
            _connectionString = settings.ConnectionString;
        }

        protected abstract string Table { get; }

        protected abstract T ToModel(SqlDataReader data);

        protected IEnumerable<T> ExecuteQuery(string queryString)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryString, connection);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    var results = new List<T>();

                    while (reader.Read())
                    {
                        results.Add(ToModel(reader));
                    }

                    return results;
                }
            }
        }
    }
}

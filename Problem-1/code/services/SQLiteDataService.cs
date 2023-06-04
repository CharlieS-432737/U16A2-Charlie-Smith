using Blazor_server_app.services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Data.SQLite;
using Dapper;

namespace Blazor_server_app.services
{
    public class SQLiteDataService
    {
        private readonly string? _connectionString;

        public SQLiteDataService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<dynamic> QueryData(string query)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                return connection.Query(query);
            }
        }
        public IEnumerable<dynamic> QueryData(string query, object parameters)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                return connection.Query(query, parameters);
            }
        }
    }
}
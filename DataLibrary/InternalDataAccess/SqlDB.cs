using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace DataLibrary.InternalDataAccess
{
    public class SqlDB : IDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDB(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionStringName = "Default")
        {
            string? connectionString = _config.GetConnectionString(connectionStringName);
            if (connectionString != null)
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    var rows = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                    return rows.ToList();
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(connectionStringName, "This Database does not exists, check your appsettings.json file.");
            }
        }

        public async Task SaveDataAsync<U>(string storedProcedure, U parameters, string connectionStringName = "Default")
        {
            string? connectionString = _config.GetConnectionString(connectionStringName);
            if (connectionString != null)
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(connectionStringName, "This Database does not exists, check your appsettings.json file.");
            }
        }
    }
}

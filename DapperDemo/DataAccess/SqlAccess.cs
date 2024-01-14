using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperDemo.DataAccess
{
    public class SqlAccess : ISqlDataAccess
    {
        private readonly IConfiguration _configuration;

        public SqlAccess(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> GetData<T , P>(string spName, P parameters, string connectionId = "DefaultConnection")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));
            

            return await connection.QueryAsync<T>(spName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string spName, T parameters, string connectionId = "DefaultConnection")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));
            await connection.ExecuteAsync(spName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}

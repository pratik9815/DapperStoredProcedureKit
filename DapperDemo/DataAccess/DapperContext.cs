using Dapper;
using DapperDemo.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperDemo.DataAccess
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        

        //Establishing a connection
        public IDbConnection CreateConnection() => 
                                        new SqlConnection(_connectionString);

        //we can use using keyword with only those class that inherit idisposable method
        //SqlConnection inherit dbconnection which in turn inherits idisposable method 
        //public async Task<IEnumerable<SuperHero>> GetSuperHero()
        //{
        //    using (var connection = CreateConnection())
        //    {
        //        var result = await connection.QueryAsync<SuperHero>("Select* from superheros");
        //        return result;
        //    }
        //}
        
    }
}

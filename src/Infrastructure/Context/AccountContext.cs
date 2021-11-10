using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context
{
    public class AccountContext : IAccountContext
    {
        private readonly IConfiguration _configuration;

        public AccountContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection OpenDatabaseConnection()
        {
            var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            return connection;
        }
    }
}
using System.Data.SqlClient;

namespace Infrastructure.Context
{
    public interface IAccountContext
    {
        SqlConnection OpenDatabaseConnection();
    }
}
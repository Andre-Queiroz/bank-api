using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Context;
using Domain.Models.Entities;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IAccountContext _accountContext;

        public AccountRepository(IAccountContext accountContext)
        {
            _accountContext = accountContext;
        }

        public async Task<Account> GetAccount(int id)
        {
            string query = "SELECT * FROM Account WHERE Id = @Id";
            SqlConnection connection = _accountContext.OpenDatabaseConnection();
            var result = await connection.QuerySingleOrDefaultAsync<Account>(sql: query, new { Id = id });
            return result;
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            string query = "SELECT * FROM Account";
            SqlConnection connection = _accountContext.OpenDatabaseConnection();
            var result = await connection.QueryAsync<Account>(sql: query);
            return result.ToList();
        }

        public async Task<int> CreateAccount(Account account)
        {
            string query = "INSERT INTO Account (Holder, Balance) VALUES (@Holder, @Balance)";
            SqlConnection connection = _accountContext.OpenDatabaseConnection();
            var numberOfAffectedLines = await connection.ExecuteAsync(sql: query, param: account);
            return numberOfAffectedLines;
        }

        public async Task<int> UpdateAccount(Account account)
        {
            string query = "UPDATE Account SET Holder = @Holder, Balance = @Balance WHERE Id = @Id";
            SqlConnection connection = _accountContext.OpenDatabaseConnection();
            int numberOfAffectedLines = await connection.ExecuteAsync(sql: query, param: account);
            return numberOfAffectedLines;
        }

        public async Task<int> DeleteAccount(int id)
        {
            string query = "DELETE FROM Account WHERE Id = @id";
            SqlConnection connection = _accountContext.OpenDatabaseConnection();
            int numberOfAffectedLines = await connection.ExecuteAsync(sql: query, new { id });
            return numberOfAffectedLines;
        }
    }
}
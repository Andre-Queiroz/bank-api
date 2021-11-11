using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Context;
using Domain.Models.Entities;
using System.Data.SqlClient;
using Dapper;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IAccountContext _accountContext;
        private readonly SqlConnection _connection;

        public AccountRepository(IAccountContext accountContext)
        {
            _accountContext = accountContext;
            _connection = _accountContext.OpenDatabaseConnection();
        }

        public async Task<Account> SelectAccount(int id)
            => await _connection.QuerySingleOrDefaultAsync<Account>(sql: "SELECT * FROM Account WHERE Id = @Id", new { Id = id });

        public async Task<IEnumerable<Account>> SelectAccounts()
            => await _connection.QueryAsync<Account>(sql: "SELECT * FROM Account");

        public async Task<int> InsertAccount(Account account)
            => await _connection.ExecuteAsync(sql: "INSERT INTO Account (Holder, Balance) VALUES (@Holder, @Balance)", param: account);

        public async Task<int> UpdateAccount(Account account)
            => await _connection.ExecuteAsync(sql: "UPDATE Account SET Holder = @Holder, Balance = @Balance WHERE Id = @Id", param: account);

        public async Task<int> DeleteAccount(int id)
            => await _connection.ExecuteAsync(sql: "DELETE FROM Account WHERE Id = @id", new { id });
    }
}
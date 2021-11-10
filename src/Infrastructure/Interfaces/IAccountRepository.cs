using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Entities;

namespace Infrastructure.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetAccount(int id);
        Task<IEnumerable<Account>> GetAccounts();
        Task<int> CreateAccount(Account account);
        Task<int> UpdateAccount(Account account);
        Task<int> DeleteAccount(int id);
    }
}
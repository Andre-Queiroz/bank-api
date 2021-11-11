using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Entities;

namespace Infrastructure.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> SelectAccount(int id);
        Task<IEnumerable<Account>> SelectAccounts();
        Task<int> InsertAccount(Account account);
        Task<int> UpdateAccount(Account account);
        Task<int> DeleteAccount(int id);
    }
}
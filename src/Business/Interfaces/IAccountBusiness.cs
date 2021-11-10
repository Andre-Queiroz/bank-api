using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Entities;

namespace Business.Interfaces
{
    public interface IAccountBusiness
    {
        Task<Account> GetAccount(int id);
        Task<IEnumerable<Account>> GetAccounts();
        Task<int> Create(Account account);
        Task<int> Update(Account account);
        Task<int> Delete(int id);
        Task<int> Withdraw(int accountNumber, double value);
        Task<int> Deposit(int accountNumber, double value);
        Task<int> Transfer(int originAccountNumber, int destinationAccountNumber, double value);
    }
}
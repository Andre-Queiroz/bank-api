using Domain.Models.Entities;
using Business.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Infrastructure.Interfaces;

namespace Business.Services
{
    public class AccountBusiness : IAccountBusiness
    {
        private readonly IAccountRepository _accountRepository;

        public AccountBusiness(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> GetAccount(int id)
        {
            Account account = await _accountRepository.GetAccount(id);
            return account;
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            IEnumerable<Account> accounts = await _accountRepository.GetAccounts();
            return accounts;
        }

        public async Task<int> Create(Account account)
        {
            int affectedRows = await _accountRepository.CreateAccount(account);
            return affectedRows;
        }

        public async Task<int> Update(Account account)
        {
            int affectedRows = await _accountRepository.UpdateAccount(account);
            return affectedRows;
        }

        public async Task<int> Delete(int id)
        {
            int affectedRows = await _accountRepository.DeleteAccount(id);
            return affectedRows;
        }

        public async Task<int> Withdraw(int accountNumber, double value)
        {
            Account account = await GetAccount(accountNumber);
            int affectedRows = 0;
            if (account.Withdraw(value))
            {
                affectedRows = await _accountRepository.UpdateAccount(account);
                return affectedRows;
            }
            return affectedRows;
        }

        public async Task<int> Deposit(int accountNumber, double value)
        {
            Account account = await GetAccount(accountNumber);
            account.Deposit(value);
            int affectedRows = await _accountRepository.UpdateAccount(account);
            return affectedRows;
        }

        public async Task<int> Transfer(int originAccountNumber, int destinationAccountNumber, double value)
        {
            Account origin = await GetAccount(originAccountNumber);
            Account destination = await GetAccount(destinationAccountNumber);

            int affectedRows = 0;
            if (origin.Transfer(destination, value))
            {
                affectedRows += await _accountRepository.UpdateAccount(origin);
                affectedRows += await _accountRepository.UpdateAccount(destination);
            }
            return affectedRows;
        }
    }
}
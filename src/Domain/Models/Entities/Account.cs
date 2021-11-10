using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Entities
{
    public class Account
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Holder { get; set; }
        [Required]
        public double Balance { get; set; }

        public bool Withdraw(double value)
        {
            if (value <= this.Balance)
            {
                this.Balance -= value;
                return true;
            }
            return false;
        }

        public void Deposit(double value)
        {
            this.Balance += value;
        }

        public bool Transfer(Account destinationAccount, double value)
        {
            if (this.Withdraw(value))
            {
                destinationAccount.Deposit(value);
                return true;
            }
            return false;
        }
    }
}
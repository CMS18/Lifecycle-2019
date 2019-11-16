using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentALM.Models
{
    public class BankRepository
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Account> Accounts { get; set; } = new List<Account>();

        //Deposit:
        public void Deposit(decimal amount, int accountNumber)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var account = Accounts.SingleOrDefault(n => n.AccountNumber == accountNumber);
            account.Balance += amount;


        }
        //Withdraw:
        public void Withdraw(decimal amount, int accountNumber)
        {
            var account = Accounts.SingleOrDefault(c => c.AccountNumber == accountNumber);
            if (amount > account.Balance || amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            account.Balance -= amount;
        }

    }
}

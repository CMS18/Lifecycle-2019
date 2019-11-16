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
        public string Deposit(int accountNumber, decimal amount)
        {
            var account = Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);

            if (account == null)
            {
                return "Invalid Account Number ";
            }

            if (amount <= 0)
            {
                return "The amount has to be positive.";
            }
            else
            {
                account.Balance += amount;
                return "Deposit Success" + " Current Balance:" +account.Balance;
            }
        }


        //Withdraw:
        public string Withdraw(decimal amount, int accountNumber)
        {
            var account = Accounts.SingleOrDefault(c => c.AccountNumber == accountNumber);
            if (account == null)
            {
                return "Invalid Account Number" ;
            }

            if (amount <= 0)
            {
                return "The amount has to be more than 0 and positive value only.";
            }
            if(account.Balance< amount)
            {
                return "Insufficient Balance"; 
            }
            else
            {
                account.Balance -= amount;
                return "Withdraw Success:" + "Current Balance:" + account.Balance;
            } 

        }

    }
}





using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentALM.Models
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public Customer AccountHolder { get; set; }
        public Decimal Balance { get; set; }

        public string Transfer(int receiver, decimal amount, BankRepository repository)
        {
            var fromAcc = repository.Accounts.FirstOrDefault(a => a.AccountNumber == AccountNumber);
            var toAcc = repository.Accounts.FirstOrDefault(a => a.AccountNumber == receiver);

            if (fromAcc == null)
            {
                return $"The account {AccountNumber} does not exist.";
            }
            if (toAcc == null)
            {
                return $"The account {receiver} does not exist.";
            }
            if(AccountNumber == receiver)
            {
                return "The receiving and sending account can't be the same.";
            }
            if (amount < 0)
            {
                return "The amount has to be positive.";
            }
            if(Balance < amount)
            {
                return "Insufficient funds.";
            }

            repository.Deposit(receiver, amount);
            repository.Withdraw(amount, AccountNumber);

            return $"Transfered {amount} from {AccountNumber} to {receiver} resulting in a balance of {toAcc.Balance}.";
        }
    }
}
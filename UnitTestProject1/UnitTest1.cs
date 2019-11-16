using AssignmentALM.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        private BankRepository repository;
        [TestMethod]
        public void Deposit()
        {
            var bankRepo = new BankRepository();


            var account = bankRepo.Accounts.SingleOrDefault(c=> c.AccountNumber == 1);
            var currentBalance = account.Balance;

            bankRepo.Deposit(5000, 1);

            var amount = account.Balance;

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(( + 500), amount);

        }

        [TestMethod]
        public void Withdraw()
        {
            var bankRepo = new BankRepository();


            var account = bankRepo.Accounts.SingleOrDefault(c => c.AccountNumber == 1);
            var currentBalance = account.Balance;

            bankRepo.Deposit(5000, 1);

            var amount = account.Balance;

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual((-500), amount);

        }
        [TestMethod]
        public void WithdrawOverLimit()
        {
            var bankRepo = new BankRepository();


            var account = bankRepo.Accounts.SingleOrDefault(c => c.AccountNumber == 1);
            var currentBalance = account.Balance;

            bankRepo.Withdraw(500000, 1);

            var amount = account.Balance;

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual((-500000), amount);

        }
    }
}

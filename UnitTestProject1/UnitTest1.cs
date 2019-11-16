using AssignmentALM.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void DepositTest()
        {
            var repo = new BankRepository();
            var account = new Account { Balance = 500m, AccountNumber = 1 };
            repo.Accounts.Add(account);

            repo.Deposit(1, 500);

            var result = repo.Accounts.First().Balance;
            var expected = 1000;

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WithdrawTest()
        {
            var repo = new BankRepository();
            var account = new Account { Balance = 500m, AccountNumber = 1 };
            repo.Accounts.Add(account);

            repo.Withdraw(500, 1);

            var result = repo.Accounts.First().Balance;
            var expected = 0;

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void OverLimitTest()
        {
            var repo = new BankRepository();
            var account = new Account { Balance = 500m, AccountNumber = 1 };
            repo.Accounts.Add(account);

            repo.Withdraw(501, 1);

            var result = repo.Accounts.First().Balance;
            var expected = 500;

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NegativeDepositTest()
        {
            var repo = new BankRepository();
            var account = new Account { Balance = 500m, AccountNumber = 1 };
            repo.Accounts.Add(account);

            repo.Deposit(-500, 1);

            var result = repo.Accounts.First().Balance;
            var expected = 500;

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, result);
        }


    }
}


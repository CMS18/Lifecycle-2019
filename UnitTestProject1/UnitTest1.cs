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

        [TestMethod]
        public void Transfer()
        {
            var repo = new BankRepository();
            var account1 = new Account { Balance = 500m, AccountNumber = 1 };
            var account2 = new Account { Balance = 500m, AccountNumber = 2 };

            repo.Accounts.Add(account1);
            repo.Accounts.Add(account2);
            var amount = 500m;

            account1.Transfer(account2.AccountNumber, amount, repo);

            var result1 = repo.Accounts.First(a => a == account1).Balance;
            var result2 = repo.Accounts.First(a => a == account2).Balance;

            var expected1 = 0;
            var expected2 = 1000;

            Assert.AreEqual(expected1, result1);
            Assert.AreEqual(expected2, result2);
        }

        [TestMethod]
        public void TransferTooMuch()
        {
            var repo = new BankRepository();
            var account1 = new Account { Balance = 50m, AccountNumber = 1 };
            var account2 = new Account { Balance = 500m, AccountNumber = 2 };

            repo.Accounts.Add(account1);
            repo.Accounts.Add(account2);
            var amount = 500m;

            account1.Transfer(account2.AccountNumber, amount, repo);

            var result1 = repo.Accounts.First(a => a == account1).Balance;
            var result2 = repo.Accounts.First(a => a == account2).Balance;

            var expected1 = 50;
            var expected2 = 500;

            Assert.AreEqual(expected1, result1);
            Assert.AreEqual(expected2, result2);
        }

    }
}


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

            var balanceUpdate = 4321m;
            repo.Deposit(500, 1);

            var result = account.Balance;

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual((balanceUpdate + 100), result);
        }

        [TestMethod]
        public void WithdrawTest()
        {
            var bank = new BankRepository();

            var account = new Account { Balance = 984m, AccountNumber = 2};

            var balanceUpdate = 230m;

            bank.Deposit(850, 2);

            var result = account.Balance;

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual((balanceUpdate - 2500), result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OverLimitTest()
        {
            var repo = new BankRepository();
            repo.Withdraw(9000023000, 3);
        }

        [TestMethod]
        public void NegativeDepositTest()
        {
            var bank = new BankRepository();

            var account = new Account { Balance = 500m, AccountNumber = 1};

            var balanceUpdate = 321m;

            bank.Deposit(-5300, 1);

            var result = account.Balance;

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual((balanceUpdate - 350), result);
        }
    }
}


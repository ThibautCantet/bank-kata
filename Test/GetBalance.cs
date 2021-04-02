using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prevoir;

namespace Test
{
    [TestClass]
    public class GetBalance
    {
        private static readonly InMemoryAccountRepository InMemoryAccountRepository = new();

        private DateTime _time = DateTime.Parse("2021-04-01");
        private Bank _bank;
        private AccountId _accountId;
        private Account _account;

        [TestInitialize]
        public void Setup()
        {
            _accountId = new AccountId();
            _account = new Account(_accountId);
            _bank = new Bank(InMemoryAccountRepository);
            
            InMemoryAccountRepository.Add(_account);
        }

        [TestMethod]
        public void should_return_sum_of_all_account_movements()
        {
            var movement1 = new Movement(_time, 600f);
            var movement2 = new Movement(_time, 500f);
            _account.Add(movement1);
            _account.Add(movement2);

            float balance = _bank.GetBalance(_accountId);

            Assert.AreEqual(balance,1100f);
        }
        
        [TestMethod]
        public void should_return_zero_when_account_has_no_movement() {
            float balance = _bank.GetBalance(_accountId);

            Assert.AreEqual(balance, 0f);
        }
    }
}
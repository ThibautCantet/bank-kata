using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prevoir;

namespace Test
{
    [TestClass]
    public class Deposit
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
        public void should_add_movement_with_deposited_amount_equal_to_500() {
            float depositedAmount = 500f;

            _bank.Deposit(_accountId, depositedAmount, _time);

            Movement expectedMovement = new Movement(_time, depositedAmount);
            Assert.AreEqual(expectedMovement, InMemoryAccountRepository.UserBalance[_accountId].GetAllMovements()[0]);
            Assert.IsTrue(new List<Movement>() {expectedMovement}.SequenceEqual(InMemoryAccountRepository.UserBalance[_accountId].GetAllMovements()));
            CollectionAssert.AreEquivalent(InMemoryAccountRepository.UserBalance[_accountId].GetAllMovements(),
                new List<Movement>() {expectedMovement});
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

using Prevoir;
using Xunit;

namespace xTest
{
    public class GetBalance
    {
        private static readonly InMemoryAccountRepository InMemoryAccountRepository = new();

        private readonly DateTime _time = DateTime.Parse("2021-04-01");
        private readonly Bank _bank;
        private readonly AccountId _accountId;
        private readonly Account _account;

        public GetBalance()
        {
            _accountId = new AccountId();
            _account = new Account(_accountId);
            _bank = new Bank(InMemoryAccountRepository);
            
            InMemoryAccountRepository.Add(_account);
        }

        [Fact]
        private void Should_return_sum_of_all_account_movements()
        {
            var movement1 = new Movement(_time, 600f);
            var movement2 = new Movement(_time, 500f);
            _account.Add(movement1);
            _account.Add(movement2);

            float balance = _bank.GetBalance(_accountId);

            Assert.Equal(1100f,balance);
        }
        
        [Fact]
        private void Should_return_zero_when_account_has_no_movement() {
            float balance = _bank.GetBalance(_accountId);

            Assert.Equal(0f, balance);
        }
    }
}
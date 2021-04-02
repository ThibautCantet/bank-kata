using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Prevoir;
using Xunit;

namespace xTest
{
    public class PrintStatement
    {
        private static readonly InMemoryAccountRepository InMemoryAccountRepository = new();

        private readonly Bank _bank;
        private readonly AccountId _accountId;
        private readonly Account _account;

        public PrintStatement()
        {
            _accountId = new AccountId();
            _account = new Account(_accountId);
            _bank = new Bank(InMemoryAccountRepository);

            InMemoryAccountRepository.Add(_account);
        }

        [Fact]
        private void Should_print_deposit_history()
        {
            _account.Add(new Movement(DateTime.Parse("2021-03-22 01:50:01"), 500f));
            _account.Add(new Movement(DateTime.Parse("2021-03-22 01:50:02"), 600f));

            String result = _bank.PrintStatement(_accountId);

            Assert.Equal("Date        Amount  Balance\n" +
                         "2021-03-22 01:50:01   +500      500\n" +
                         "2021-03-22 01:50:02   +600      1100", result);
        }

        [Fact]
        private void Should_print_deposit_history_when_no_movement()
        {
            String result = _bank.PrintStatement(_accountId);

            Assert.Equal("Date        Amount  Balance", result);
        }
    }
}
using System;
using FluentAssertions;
using Xunit;

namespace Bank.kata
{
    public class Deposit
    {
        private static readonly InMemoryAccountRepository InMemoryAccountRepository = new();

        private readonly DateTime _time = DateTime.Parse("2021-04-01");
        private readonly Bank _bank;
        private readonly AccountId _accountId;

        public Deposit()
        {
            _accountId = new AccountId();
            var account = new Account(_accountId);
            _bank = new Bank(InMemoryAccountRepository);

            InMemoryAccountRepository.Add(account);
        }

        [Fact]
        private void Should_add_movement_with_deposited_amount_equal_to_500()
        {
            float depositedAmount = 500f;

            _bank.Deposit(_accountId, depositedAmount, _time);

            Movement expectedMovement = new Movement(_time, depositedAmount);
            InMemoryAccountRepository.UserBalance[_accountId].Movements.Should()
                .BeEquivalentTo(expectedMovement);
        }

        [Fact]
        private void Should_add_movement_with_deposited_amount_equal_to_600()
        {
            float depositedAmount = 600f;

            _bank.Deposit(_accountId, depositedAmount, _time);

            Movement expectedMovement = new Movement(_time, depositedAmount);
            InMemoryAccountRepository.UserBalance[_accountId].Movements.Should()
                .BeEquivalentTo(expectedMovement);
        }

        [Fact]
        private void Should_throw_exception_when_amount_is_negative()
        {
            var exception = Assert.Throws<Exception>(() => _bank.Deposit(_accountId, -600f, _time));

            Assert.Contains("Negative amount", exception.Message);
        }

        [Fact]
        private void Should_throw_exception_when_amount_is_null()
        {
            var exception = Assert.Throws<Exception>(() => _bank.Deposit(_accountId, null, _time));

            Assert.Contains("Null amount", exception.Message);
        }

        [Fact]
        private void Should_throw_exception_when_accountId_is_null()
        {
            var exception = Assert.Throws<Exception>(() => _bank.Deposit(null, 10f, _time));

            Assert.Contains("Null account id", exception.Message);
        }
        
        [Fact]
        private void Should_throw_exception_when_accountId_doesnt_exist() {
            var exception = Assert.Throws<Exception>(() => _bank.Deposit(new AccountId(), 10f, _time));

            Assert.Contains("Account id doesn't exist", exception.Message);
        }
    }
}
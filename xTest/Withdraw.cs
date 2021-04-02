using System;
using FluentAssertions;
using Prevoir;
using Xunit;

namespace xTest
{
    public class Withdraw
    {
        private static readonly InMemoryAccountRepository InMemoryAccountRepository = new();

        private readonly DateTime _time = DateTime.Parse("2021-04-01");
        private readonly Bank _bank;
        private readonly AccountId _accountId;

        public Withdraw()
        {
            _accountId = new AccountId();
            var account = new Account(_accountId);
            _bank = new Bank(InMemoryAccountRepository);

            InMemoryAccountRepository.Add(account);
        }


        [Fact]
        private void Should_add_movement_with_deposited_amount_equal_to_500()
        {
            float withdrawnAmount = 500f;

             _bank.Withdraw(_accountId, withdrawnAmount, _time);

            Movement expectedMovement = new Movement(_time, -withdrawnAmount);
            InMemoryAccountRepository.UserBalance[_accountId].GetAllMovements().Should()
                .BeEquivalentTo(expectedMovement);
        }

        [Fact]
        private void Should_add_movement_with_withdrawn_amount_equal_to_600()
        {
            float withdrawnAmount = 600f;

             _bank.Withdraw(_accountId, withdrawnAmount, _time);

            Movement expectedMovement = new Movement(_time, -withdrawnAmount);
            InMemoryAccountRepository.UserBalance[_accountId].GetAllMovements().Should()
                .BeEquivalentTo(expectedMovement);
        }

        [Fact]
        private void Should_throw_exception_when_amount_is_negative()
        {
            var exception = Assert.Throws<Exception>(() => _bank.Withdraw(_accountId, -600f, _time));

            Assert.Contains("Negative amount", exception.Message);
        }

        [Fact]
        private void Should_throw_exception_when_amount_is_null()
        {
            var exception = Assert.Throws<Exception>(() => _bank.Withdraw(_accountId, null, _time));

            Assert.Contains("Null amount", exception.Message);
        }

        [Fact]
        private void Should_throw_exception_when_accountId_is_null()
        {
            var exception = Assert.Throws<Exception>(() => _bank.Withdraw(null, 600f, _time));

            Assert.Contains("Null account id", exception.Message);
        }
    }
}
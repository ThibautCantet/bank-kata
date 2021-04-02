using System;
using FluentAssertions;
using Moq;

using Xunit;

namespace Bank.kata
{
    public class DepositWithMock
    {
        private static IAccountRepository _accountRepository;

        private readonly DateTime _time = DateTime.Parse("2021-04-01");
        private readonly Bank _bank;
        private readonly AccountId _accountId;
        private Mock<IAccountRepository> _accountRepositoryMock;
        private Account _account;

        public DepositWithMock()
        {
            _accountId = new AccountId();
            _account = new Account(_accountId);

            _accountRepositoryMock = new Mock<IAccountRepository>();

            _accountRepositoryMock.Setup(accountRepository => accountRepository.FindById(It.IsAny<AccountId>())).Returns(_account);

            _accountRepository = _accountRepositoryMock.Object;
            
            _bank = new Bank(_accountRepository);
        }

        [Fact]
        private void Should_add_movement_with_deposited_amount_equal_to_500()
        {
            float depositedAmount = 500f;

            _bank.Deposit(_accountId, depositedAmount, _time);

            _accountRepositoryMock.Verify(x => x.Save(_account));
        }

        [Fact]
        private void Should_add_movement_with_deposited_amount_equal_to_600()
        {
            float depositedAmount = 600f;

            _bank.Deposit(_accountId, depositedAmount, _time);

            _accountRepositoryMock.Verify(x => x.Save(_account));
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
            _accountRepositoryMock.Setup(accountRepository => accountRepository.FindById(It.IsAny<AccountId>())).Returns((Account) null);
            
            var exception = Assert.Throws<Exception>(() => _bank.Deposit(new AccountId(), 10f, _time));

            Assert.Contains("Account id doesn't exist", exception.Message);
        }
    }
}
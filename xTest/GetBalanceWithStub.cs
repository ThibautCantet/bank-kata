using System;
using System.Collections.Generic;
using Moq;
using Prevoir;
using Xunit;

namespace xTest
{
    public class GetBalanceWithStub
    {
        private readonly DateTime _time = DateTime.Parse("2021-04-01");
        private readonly Bank _bank;
        private readonly AccountId _accountId;
        private readonly Mock<Account> _mockAccount;

        public GetBalanceWithStub()
        {
            _accountId = new AccountId();
            _mockAccount = new Mock<Account>();

            var mockIAccountRepository = new Mock<IAccountRepository>();
            mockIAccountRepository.Setup(accountRepository => accountRepository.FindById(It.IsAny<AccountId>())).Returns(_mockAccount.Object);

            _bank = new Bank(mockIAccountRepository.Object);
        }

        [Fact]
        private void Should_return_sum_of_all_account_movements()
        {
            var movement1 = new Movement(_time, 600f);
            var movement2 = new Movement(_time, 500f);
            _mockAccount.Setup(account => account.Movements).Returns(new List<Movement> { movement1, movement2});

            float balance = _bank.GetBalance(_accountId);

            Assert.Equal(1100f,balance);
        }
        
        [Fact]
        private void Should_return_zero_when_account_has_no_movement() {
            _mockAccount.Setup(account => account.Movements).Returns(new List<Movement>());
            
            float balance = _bank.GetBalance(_accountId);

            Assert.Equal(0f, balance);
        }
    }
}
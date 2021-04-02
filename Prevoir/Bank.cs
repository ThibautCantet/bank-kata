using System;
using System.Collections.Generic;
using System.Linq;

namespace Prevoir
{
    public class Bank
    {
        private readonly IAccountRepository _accountRepository;

        public Bank(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public float GetBalance(AccountId accountId)
        {
            Account account = FindAccountById(accountId);
            return account.GetAllMovements()
                .Aggregate(0f, (acc, x) => acc + x.Amount);
        }

        public void Deposit(AccountId accountId, float? depositedAmount, DateTime time)
        {
            if (depositedAmount == null) {
                throw new Exception("Null amount");
            }
            if (accountId == null) {
                throw new Exception("Null account id");
            }
            if (depositedAmount < 0) {
                throw new Exception("Negative amount");
            }
            Account account = _accountRepository.FindById(accountId);
            if (account == null) {
                throw new Exception("Account id doesn't exist");
            }
            Movement movement = new Movement(time, depositedAmount.Value);
            account.Add(movement);
        }

        public void Withdraw(AccountId accountId, float? withdrawnAmount, DateTime dateTime) {
            if (withdrawnAmount == null) {
                throw new Exception("Null amount");
            }
            if (accountId == null) {
                throw new Exception("Null account id");
            }
            if (withdrawnAmount < 0) {
                throw new Exception("Negative amount");
            }
            Account account = _accountRepository.FindById(accountId);
            if (account == null) {
                throw new Exception("Account id doesn't exist");
            }
            Movement movement = new Movement(dateTime, -withdrawnAmount.Value);
            account.Add(movement);
        }

        public String PrintStatement(AccountId accountId) {
            Account account = FindAccountById(accountId);
            String lines = account.GetAllMovements().Aggregate(
                "", (s1, s2) =>s1 + "\n" + BuildCurrentBalance(s2, account.GetAllMovements()));

            return "Date        Amount  Balance" + lines;
        }

        private String BuildCurrentBalance(Movement currentMovement, List<Movement> allMovements)
        {
            float currentBalance = allMovements
                .Where(movement =>  IsBeforeOrEqual(currentMovement, movement))
                .Aggregate(
                0f, (acc, movement) => acc + movement.Amount);
            return currentMovement.Time.ToString("yyyy-MM-dd hh:mm:ss") + "   +" + currentMovement.Amount + "      " + currentBalance;
        }

        private bool IsBeforeOrEqual(Movement currentMovement, Movement movement) {
            return movement.Time.CompareTo(currentMovement.Time) == -1 || movement.Time.CompareTo(currentMovement.Time) == 0;
        }

        private Account FindAccountById(AccountId accountId) {
            return _accountRepository.FindById(accountId);
        }
    }
}
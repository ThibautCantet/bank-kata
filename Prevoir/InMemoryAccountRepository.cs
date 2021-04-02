using System.Collections.Generic;

namespace Prevoir
{
    public class InMemoryAccountRepository: IAccountRepository
    {
        public InMemoryAccountRepository()
        {
            UserBalance = new Dictionary<AccountId, Account>();
        }

        public Dictionary<AccountId, Account> UserBalance { get; }

        public Account FindById(AccountId accountId)
        {
            UserBalance.TryGetValue(accountId, out var account);
            return account;
        }

        public void Add(Account account)
        {
            UserBalance.Add(account.Id, account);
        }

        public void Save(Account account)
        {
            UserBalance[account.Id] = account;
        }
    }
}
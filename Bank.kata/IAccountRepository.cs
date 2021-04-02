namespace Bank.kata
{
    public interface IAccountRepository
    {
        Account FindById(AccountId accountId);

        void Add(Account account);
        void Save(Account account);
    }
}
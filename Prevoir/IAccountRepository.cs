namespace Prevoir
{
    public interface IAccountRepository
    {
        Account FindById(AccountId accountId);

        void Add(Account account);
    }
}
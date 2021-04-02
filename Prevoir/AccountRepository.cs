namespace Prevoir
{
    public interface AccountRepository
    {
        Account FindById(AccountId accountId);

        void Add(Account account);
    }
}
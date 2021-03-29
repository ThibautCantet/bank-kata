package bank;

import java.util.HashMap;
import java.util.Optional;

public class InMemoryAccountRepository implements AccountRepository {
    public final HashMap<AccountId, Account> userBalance;

    public InMemoryAccountRepository() {
        userBalance = new HashMap<>();
    }

    @Override
    public Optional<Account> findById(AccountId accountId) {
        return Optional.ofNullable(userBalance.get(accountId));
    }

    @Override
    public void add(Account account) {
        userBalance.putIfAbsent(account.getAccountId(), account);
    }
}

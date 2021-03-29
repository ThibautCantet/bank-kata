package bank;

import java.util.Optional;

public interface AccountRepository {
    Optional<Account> findById(AccountId accountId);

    void add(Account account);

}

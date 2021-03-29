package bank;

import java.time.Clock;
import java.time.LocalDateTime;
import java.util.Optional;

public class Bank {

    private final AccountRepository accountRepository;

    public Bank(AccountRepository accountRepository) {
        this.accountRepository = accountRepository;
    }

    public void deposit(AccountId accountId, Float depositedAmount, Clock clock) {
        if (depositedAmount == null) {
            throw new RuntimeException("Null amount");
        }
        if (accountId == null) {
            throw new RuntimeException("Null account id");
        }
        if (depositedAmount < 0) {
            throw new RuntimeException("Negative amount");
        }
        final Optional<Account> optionalAccount = accountRepository.findById(accountId);
        if (!optionalAccount.isPresent()) {
            throw new RuntimeException("Account id doesn't exist");
        }
        final Movement movement = new Movement(LocalDateTime.now(clock), depositedAmount);
        final Account account = optionalAccount.get();
        account.add(movement);
    }

    public Float getBalance(AccountId accountId) {
        final Account account = findAccountById(accountId);
        return account.getAllMovements().stream()
                .map(Movement::getAmount)
                .reduce(Float::sum)
                .orElse(0f);
    }

    public String printStatement(AccountId accountId) {
        final Account account = findAccountById(accountId);
        final String lines = account.getAllMovements().stream()
                .map(movement -> movement.getTime() + "   +" + movement.getAmount() + "      500")
                .reduce("", (s1, s2) -> s1 + "\n" + s2);

        return "Date        Amount  Balance"+lines;
    }

    private Account findAccountById(AccountId accountId) {
        final Optional<Account> optionalAccount = accountRepository.findById(accountId);
        return optionalAccount.get();
    }
}

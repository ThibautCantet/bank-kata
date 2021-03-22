package bank;

import java.time.Clock;
import java.time.LocalDateTime;
import java.util.HashMap;

public class Bank {

    private final HashMap<AccountId, Account> userBalance;

    public Bank() {
        userBalance = new HashMap<>();
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
        final Movement movement = new Movement(LocalDateTime.now(clock), depositedAmount);
        final Account account = userBalance.getOrDefault(accountId, new Account());
        account.add(movement);
        userBalance.putIfAbsent(accountId, account);
    }

    public Float getBalance(AccountId accountId) {
        final Account account = userBalance.get(accountId);
        return account.getLastMovement();
    }

    public String printStatement(AccountId accountId) {
        final Account account = userBalance.get(accountId);
        final String lines = account.getAllMovements().stream()
                .map(movement -> movement.getTime() + "   +" + movement.getAmount() + "      500")
                .reduce("", (s1, s2) -> s1 + "\n" + s2);

        return "Date        Amount  Balance"+lines;
    }
}

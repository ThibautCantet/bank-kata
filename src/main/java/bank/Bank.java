package bank;

import java.util.HashMap;

public class Bank {

    private final HashMap<AccountId, Float> userBalance;

    public Bank() {
        userBalance = new HashMap<>();
    }

    public void deposit(AccountId accountId, Float depositedAmount) {
        if (depositedAmount < 0) {
            throw new RuntimeException("Negative amount");
        }
        userBalance.putIfAbsent(accountId, depositedAmount);
    }

    public Float getBalance(AccountId accountId) {
        return userBalance.get(accountId);
    }
}

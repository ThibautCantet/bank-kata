package bank;

import java.util.HashMap;

public class Bank {

    private final HashMap<User, Float> userBalance;

    public Bank() {
        userBalance = new HashMap<>();
    }

    public void deposit(User user, Float depositedAmount) {
        if (depositedAmount < 0) {
            throw new RuntimeException("Negative amount");
        }
        userBalance.putIfAbsent(user, depositedAmount);
    }

    public Float getBalance(User user) {
        return userBalance.get(user);
    }
}

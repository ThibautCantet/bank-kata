package bank;

import java.util.HashMap;

public class Bank {

    private HashMap<User, Float> userBalance;

    public void deposit(User user, Float depositedAmount) {
        userBalance = new HashMap<>();
        userBalance.putIfAbsent(user, depositedAmount);
    }

    public Float getBalance(User user) {
        return userBalance.get(user);
    }
}

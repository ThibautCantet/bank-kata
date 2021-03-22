package bank;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;

class BankUTest {

    private Bank bank;

    @BeforeEach
    void setUp() {
        bank = new Bank();
    }

    @Test
    void deposit_should_update_user_balance_with_deposited_amount_equal_to_500() {
        Float depositedAmount = 500f;

        final User user = new User();

        bank.deposit(user, depositedAmount);

        assertThat(bank.getBalance(user)).isEqualTo(depositedAmount);
    }

    @Test
    void deposit_should_update_user_balance_with_deposited_amount_equal_to_600() {
        Float depositedAmount = 600f;

        final User user = new User();

        bank.deposit(user, depositedAmount);

        assertThat(bank.getBalance(user)).isEqualTo(depositedAmount);
    }
}
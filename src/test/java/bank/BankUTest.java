package bank;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;
import static org.assertj.core.api.Assertions.catchThrowable;

class BankUTest {

    private Bank bank;

    @BeforeEach
    void setUp() {
        bank = new Bank();
    }

    @Test
    void deposit_should_update_user_balance_with_deposited_amount_equal_to_500() {
        Float depositedAmount = 500f;

        final AccountId accountId = new AccountId();

        bank.deposit(accountId, depositedAmount);

        assertThat(bank.getBalance(accountId)).isEqualTo(depositedAmount);
    }

    @Test
    void deposit_should_update_user_balance_with_deposited_amount_equal_to_600() {
        Float depositedAmount = 600f;

        final AccountId accountId = new AccountId();

        bank.deposit(accountId, depositedAmount);

        assertThat(bank.getBalance(accountId)).isEqualTo(depositedAmount);
    }

    @Test
    void deposit_should_throw_exception_when_amount_is_negative() {
        final AccountId accountId = new AccountId();

        final Throwable throwable = catchThrowable(() -> bank.deposit(accountId, -600f));

        assertThat(throwable).isEqualToComparingFieldByField(new RuntimeException("Negative amount"));
    }
}
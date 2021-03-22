package bank;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Nested;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;
import static org.assertj.core.api.Assertions.catchThrowable;

class BankUTest {

    private Bank bank;

    @BeforeEach
    void setUp() {
        bank = new Bank();
    }

    @Nested
    class Deposit {
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

            assertThat(throwable).isEqualToComparingFieldByField(new RuntimeException());
            assertThat(throwable.getMessage()).isEqualTo("Negative amount");
        }

        @Test
        void deposit_should_throw_exception_when_amount_is_null() {
            final AccountId accountId = new AccountId();

            final Throwable throwable = catchThrowable(() -> bank.deposit(accountId, null));

            assertThat(throwable).isEqualToComparingFieldByField(new RuntimeException());
            assertThat(throwable.getMessage()).isEqualTo("Null amount");
        }

        @Test
        void deposit_should_throw_exception_when_accountId_is_null() {
            final Throwable throwable = catchThrowable(() -> bank.deposit(null, 10f));

            assertThat(throwable).isEqualToComparingFieldByField(new RuntimeException());
            assertThat(throwable.getMessage()).isEqualTo("Null account id");
        }
    }
}
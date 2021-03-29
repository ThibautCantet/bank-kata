package bank;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Nested;
import org.junit.jupiter.api.Test;

import java.time.Clock;
import java.time.LocalDateTime;

import static java.time.ZoneOffset.UTC;
import static org.assertj.core.api.Assertions.assertThat;
import static org.assertj.core.api.Assertions.catchThrowable;

class BankUTest {

    private Bank bank;

    private Clock clock;

    private AccountId accountId;
    private Account account;

    private final AccountRepository accountRepository = new InMemoryAccountRepository();

    private static final LocalDateTime NOW = LocalDateTime.of(2021, 3, 22, 1, 50, 1);

    @BeforeEach
    void setUp() {
        bank = new Bank(accountRepository);

        clock = Clock.fixed(NOW.toInstant(UTC), UTC);

        accountId = new AccountId();
        account = new Account(accountId);
        accountRepository.add(account);
    }

    @Nested
    class Deposit {

        @Nested
        class WhenAccountIdExist {

            @Test
            void should_update_user_balance_with_deposited_amount_equal_to_500() {
                Float depositedAmount = 500f;

                bank.deposit(accountId, depositedAmount, clock);

                assertThat(bank.getBalance(accountId)).isEqualTo(depositedAmount);
            }

            @Test
            void should_update_user_balance_with_deposited_amount_equal_to_600() {
                Float depositedAmount = 600f;

                bank.deposit(accountId, depositedAmount, clock);

                assertThat(bank.getBalance(accountId)).isEqualTo(depositedAmount);
            }

            @Test
            void should_throw_exception_when_amount_is_negative() {
                final Throwable throwable = catchThrowable(() -> bank.deposit(accountId, -600f, clock));

                assertThat(throwable).isEqualToComparingFieldByField(new RuntimeException());
                assertThat(throwable.getMessage()).isEqualTo("Negative amount");
            }

            @Test
            void should_throw_exception_when_amount_is_null() {
                final Throwable throwable = catchThrowable(() -> bank.deposit(accountId, null, clock));

                assertThat(throwable).isEqualToComparingFieldByField(new RuntimeException());
                assertThat(throwable.getMessage()).isEqualTo("Null amount");
            }

            @Test
            void should_throw_exception_when_accountId_is_null() {
                final Throwable throwable = catchThrowable(() -> bank.deposit(null, 10f, clock));

                assertThat(throwable).isEqualToComparingFieldByField(new RuntimeException());
                assertThat(throwable.getMessage()).isEqualTo("Null account id");
            }
        }

        @Test
        void should_throw_exception_when_accountId_doesnt_exist() {
            final Throwable throwable = catchThrowable(() -> bank.deposit(new AccountId(), 10f, clock));

            assertThat(throwable).isEqualToComparingFieldByField(new RuntimeException());
            assertThat(throwable.getMessage()).isEqualTo("Account id doesn't exist");
        }
    }

    @Nested
    class PrintStatement {
        @Test
        void should_print_deposit_history() {
            bank.deposit(accountId, 500f, clock);

            clock = Clock.fixed(LocalDateTime.of(2021, 3, 22, 1, 50, 2).toInstant(UTC), UTC);
            bank.deposit(accountId, 600f, clock);

            String result = bank.printStatement(accountId);

            assertThat(result).isEqualTo("Date        Amount  Balance\n" +
                    "2021-03-22T01:50:01   +500.0      500\n" +
                    "2021-03-22T01:50:02   +600.0      500");
        }
    }
}
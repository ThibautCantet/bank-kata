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

    private final InMemoryAccountRepository accountRepository = new InMemoryAccountRepository();

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
    class GetBalance {

        @Test
        void should_return_sum_of_all_account_movements() {
            account.add(new Movement(LocalDateTime.now(clock), 600f));
            account.add(new Movement(LocalDateTime.now(clock), 500f));

            final Float balance = bank.getBalance(accountId);

            assertThat(balance).isEqualTo(1100f);
        }

        @Test
        void should_return_zero_when_account_has_no_movement() {
            final Float balance = bank.getBalance(accountId);

            assertThat(balance).isEqualTo(0f);
        }
    }

    @Nested
    class Deposit {

        @Nested
        class WhenAccountExists {

            @Test
            void should_add_movement_with_deposited_amount_equal_to_500() {
                Float depositedAmount = 500f;

                bank.deposit(accountId, depositedAmount, clock);

                final Movement expectedMovement = new Movement(LocalDateTime.now(clock), depositedAmount);
                assertThat(accountRepository.userBalance.get(accountId).getAllMovements()).usingRecursiveFieldByFieldElementComparator().containsExactly(expectedMovement);
            }

            @Test
            void should_add_movement_with_deposited_amount_equal_to_600() {
                Float depositedAmount = 600f;

                bank.deposit(accountId, depositedAmount, clock);

                final Movement expectedMovement = new Movement(LocalDateTime.now(clock), depositedAmount);
                assertThat(accountRepository.userBalance.get(accountId).getAllMovements()).usingRecursiveFieldByFieldElementComparator().containsExactly(expectedMovement);
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
            account.add(new Movement(LocalDateTime.of(2021, 3, 22, 1, 50, 1), 500f));
            account.add(new Movement(LocalDateTime.of(2021, 3, 22, 1, 50, 2), 600f));

            String result = bank.printStatement(accountId);

            assertThat(result).isEqualTo("Date        Amount  Balance\n" +
                    "2021-03-22T01:50:01   +500.0      500.0\n" +
                    "2021-03-22T01:50:02   +600.0      1100.0");
        }

        @Test
        void should_print_deposit_history_when_no_movement() {
            String result = bank.printStatement(accountId);

            assertThat(result).isEqualTo("Date        Amount  Balance");
        }
    }
}
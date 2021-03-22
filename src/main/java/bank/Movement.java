package bank;

import java.time.LocalDateTime;

public class Movement {
    private final LocalDateTime time;
    private final Float amount;

    public Movement(LocalDateTime time, Float amount) {
        this.time = time;
        this.amount = amount;
    }

    public Float getAmount() {
        return amount;
    }

    public LocalDateTime getTime() {
        return time;
    }
}

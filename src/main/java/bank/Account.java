package bank;

import java.util.ArrayList;
import java.util.List;

public class Account {
    private final List<Movement> movements;

    public Account() {
        movements = new ArrayList<>();
    }

    public void add(Movement movement) {
        movements.add(movement);
    }

    public Float getLastMovement() {
        final Movement movement = movements.get(movements.size() - 1);
        return movement.getAmount();
    }

    public List<Movement> getAllMovements() {
        return movements;
    }
}

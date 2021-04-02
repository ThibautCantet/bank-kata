using System.Collections.Generic;

namespace Prevoir
{
    public class Account
    {
        public List<Movement> Movements { get; }
        public AccountId Id { get; }

        public Account(AccountId accountId)
        {
            Id = accountId;
            Movements = new List<Movement>();
        }

        public void Add(Movement movement)
        {
            Movements.Add(movement);
        }

        public float getLastMovement()
        {
            Movement movement = Movements[Movements.Count - 1];
            return movement.Amount;
        }

        public List<Movement> GetAllMovements()
        {
            return Movements;
        }
    }
}
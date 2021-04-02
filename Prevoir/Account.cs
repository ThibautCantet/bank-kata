using System.Collections.Generic;

namespace Prevoir
{
    public class Account
    {
        public virtual List<Movement> Movements { get; }
        public AccountId Id { get; }

        protected Account()
        {
        }

        public Account(AccountId accountId)
        {
            Id = accountId;
            Movements = new List<Movement>();
        }

        public void Add(Movement movement)
        {
            Movements.Add(movement);
        }
    }
}
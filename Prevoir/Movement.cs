using System;
using System.Collections.Generic;

namespace Prevoir
{
    public class Movement
    {
        public DateTime Time { get; }
        public float Amount { get; }

        public Movement(DateTime time, float amount) {
            Time = time;
            Amount = amount;
        }
    }
}
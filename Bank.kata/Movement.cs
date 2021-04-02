using System;
using System.Collections.Generic;

namespace Bank.kata
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
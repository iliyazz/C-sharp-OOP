﻿namespace Bakery.Models.Tables
{
    public class OutsideTable :Table
    {
        private const decimal INITIALPRICEPERPERSON = 3.5M;
        public OutsideTable(int tableNumber, int capacity)
            : base(tableNumber, capacity, INITIALPRICEPERPERSON)
        {
        }
    }
}

namespace Bakery.Models.Tables
{
    using Contracts;

    public class InsideTable : Table
    {
        private const decimal INITIALPRICEPERPERSON = 2.5M;
        public InsideTable(int tableNumber, int capacity)
            : base(tableNumber, capacity, INITIALPRICEPERPERSON)
        {
        }
    }
}

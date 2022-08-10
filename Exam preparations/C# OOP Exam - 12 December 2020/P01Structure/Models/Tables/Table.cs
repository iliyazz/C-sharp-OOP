namespace Bakery.Models.Tables
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using BakedFoods.Contracts;
    using Contracts;
    using Drinks.Contracts;
    using Utilities.Messages;

    public abstract class Table :ITable
    {
        //private int tableNumber;
        private int capacity;
        private decimal pricePerPerson;
        private readonly ICollection<IBakedFood> foodOrders;
        private readonly ICollection<IDrink> drinkOrders;
        private int numberOfPeople;


        private Table()
        {
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
        }
        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        : this()
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }



        public int TableNumber { get; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numberOfPeople = value;
            }
        }
        public decimal PricePerPerson { get; }

        public bool IsReserved { get; private set; }

        public decimal Price => pricePerPerson * NumberOfPeople;
        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            IsReserved = true;
        }

        public void OrderFood(IBakedFood food) => this.foodOrders.Add(food);

        public void OrderDrink(IDrink drink) => this.drinkOrders.Add(drink);

        public decimal GetBill() => Price;

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public string GetFreeTableInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}")
                .AppendLine($"Type: {this.GetType()}")
                .AppendLine($"Capacity: {this.Capacity}")
                .AppendLine($"Price per Person: {this.pricePerPerson}");
            return sb.ToString().TrimEnd();
        }
    }
}

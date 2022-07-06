
namespace P03ShoppingSpree
{
    using System;
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get 
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.EmptyName);
                }
                this.name = value;
            }
        }
        public decimal Cost 
        {
            get 
            { 
                return this.cost;
            }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(ErrorMessages.NegativeMoney);
                }
                this.cost = value;
            } 
        }
    }
}

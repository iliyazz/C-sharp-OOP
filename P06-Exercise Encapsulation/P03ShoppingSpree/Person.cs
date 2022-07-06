
namespace P03ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string name;
        private decimal money;
        private readonly  List<Product> products;

        private Person()
        {
            this.products = new List<Product>();
        }
        public Person(string name, decimal money)
            :this()
        {
            this.Name = name;
            this.Money = money;
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
        public decimal Money 
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ErrorMessages.NegativeMoney);
                }
                this.money = value;
            }
        }
        public bool AddProduct(Product product)
        {
            if (Money - product.Cost <0)
            {
                return false;
            }
            this.products.Add(product);
            this.Money -= product.Cost;
            return true;
        }

        public IReadOnlyCollection<Product> Products
        {
            get
            {
                return this.products;
            }
        }
    }
}

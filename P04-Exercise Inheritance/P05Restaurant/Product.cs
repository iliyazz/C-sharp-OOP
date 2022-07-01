using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Product
    {
        private string name;
        private decimal price;

        public string Name { get => name; set => name = value; }
        public decimal Price { get => price; set => price = value; }

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}

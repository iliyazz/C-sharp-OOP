
using System.Collections.Generic;
using System;
using System.Linq;

namespace P04PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        public string Name 
        {
            get
            {
                return name;
            }
            set
            {
                if(string.IsNullOrWhiteSpace(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException(ErrorMessages.PizzaNameErrMessage);
                }
                name = value;
            }
        }
        public Dough Dough { get; private set; }
        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
            this.Dough = dough;
        }
        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new ArgumentException(ErrorMessages.ToppingsCountErrmessage);
            }
            toppings.Add(topping);
        }
        public double Totalcalories =>
            this.Dough.Calories + toppings.Sum(x => x.Calories);
    }
}

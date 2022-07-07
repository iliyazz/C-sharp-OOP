
namespace P04PizzaCalories
{
    using System;
    using System.Collections.Generic;
    public class Topping
    {
        private int weight;
        private string toppingType;
        public Topping(string toppingType, int weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }
        public string ToppingType
        {
            get 
            { 
                return toppingType; 
            }
            private set 
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value; 
            }
        }
        public int Weight
        {
            get 
            { 
                return weight; 
            }
            private set 
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
                }
                weight = value; 
            }
        }
        private readonly Dictionary<string, double> modifiers = new Dictionary<string, double>()
        {
            {"meat", 1.2 },
            { "veggies", 0.8 },
            { "cheese", 1.1 },
            { "sauce", 0.9 }
        };
        public double Calories => 2 * this.Weight * modifiers[this.ToppingType.ToLower()];
    }
}

namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;
    using Foods;
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }
        protected abstract IReadOnlyCollection<Type> PreferredFoods { get; }
        protected abstract double WeightMultiplier { get; }
        public void Eat(Food food)
        {
            if (!this.PreferredFoods.Contains(food.GetType()))
            {
                throw new FoodNotPreferredException(
                    String.Format(ExceptionMessages.FoodNotPreferred, this.GetType().Name, food.GetType().Name));
            }
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightMultiplier;
        }
        public abstract string ProduceSound();
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}

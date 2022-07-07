
namespace P04PizzaCalories
{
    using System;
    using System.Collections.Generic;
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int weight;
        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }
        public string FlourType 
        {
            get 
            {
                return flourType;
            } 
            private set
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(ErrorMessages.DoughTypeErrMessage);
                }
                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get
            {
                return bakingTechnique;
            }
            private set 
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(ErrorMessages.DoughTypeErrMessage);
                }
                bakingTechnique = value;
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
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(ErrorMessages.DoughWeightErrMessage);
                }
                weight = value;
            } 
        }
        private readonly Dictionary<string, double> modifiers = new Dictionary<string, double>()
        {
            {"white", 1.5 },
            { "wholegrain", 1.0 },
            { "crispy", 0.9 },
            { "chewy", 1.1 },
            { "homemade", 1.0 }
        };
        public double Calories => 2 * this.Weight * modifiers[this.FlourType.ToLower()] * modifiers[this.BakingTechnique.ToLower()];

    }
}

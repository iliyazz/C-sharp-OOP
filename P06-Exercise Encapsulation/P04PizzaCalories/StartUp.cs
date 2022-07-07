using System;

namespace P04PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] pizzaTokens = Console.ReadLine().Split();
            string name = pizzaTokens[1];
            string[] doughToken = Console.ReadLine().Split();
            string flourType = doughToken[1];
            string bakingTechnique = doughToken[2];
            int weight = int.Parse(doughToken[3]);
            try
            {
                Dough dough = new Dough(flourType, bakingTechnique, weight);
                Pizza pizza = new Pizza(name, dough);
                string tokens = string.Empty;
                while ((tokens = Console.ReadLine()) != "END")
                {
                    string[] toppingTokens = tokens.Split();
                    string toppingType = toppingTokens[1];
                    int toppingWeight = int.Parse(toppingTokens[2]);
                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);
                 }
                Console.WriteLine($"{pizza.Name} - {pizza.Totalcalories:f2} Calories.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

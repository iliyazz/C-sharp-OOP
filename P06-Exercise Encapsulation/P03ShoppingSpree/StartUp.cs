using System;
using System.Collections.Generic;
using System.Linq;

namespace P03ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string[] peopleInput = Console.ReadLine().Split(new char[] {';','=' }, StringSplitOptions.RemoveEmptyEntries);
            string[] productsInput = Console.ReadLine().Split(new char[] {';','=' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            try
            {
                for (int i = 0; i < peopleInput.Length; i += 2)
                {
                    string name = peopleInput[i];
                    decimal money = decimal.Parse(peopleInput[i + 1]);
                    Person person = new Person(name, money);
                    people.Add(name, person);
                }
                for (int i = 0; i < productsInput.Length; i += 2)
                {
                    string name = productsInput[i];
                    decimal cost = decimal.Parse(productsInput[i + 1]);
                    Product product = new Product(name, cost);
                    products.Add(name, product);
                }

                string command = string.Empty;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] cmdArg = command.Split();
                    string personName = cmdArg[0];
                    string productName = cmdArg[1];
                    Person person = people[personName];
                    Product product = products[productName];
                    bool isEnoughMoney = person.AddProduct(product);
                    if (!isEnoughMoney)
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");
                    }
                    else
                    {
                        Console.WriteLine($"{personName} bought {productName}");
                    }
                }
                foreach (var item/*(name, person)*/ in people)
                {
                    if (item.Value.Products.Count > 0)
                    {
                        Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value.Products.Select(x => x.Name))}");
                    }
                    else
                    {
                        Console.WriteLine($"{item.Key} - Nothing bought");
                    }
                    
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}

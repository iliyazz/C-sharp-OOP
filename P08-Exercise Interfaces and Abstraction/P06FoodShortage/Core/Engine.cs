
namespace FoodShortage.Core
{
    using FoodShortage.IO.Contracts;
    using FoodShortage.Models;
    using FoodShortage.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private List<Ibuyer> repositry;
        
        public Engine(IReader reader, IWriter writer)
        {
            this.repositry = new List<Ibuyer>();
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPeople; i++)
            {
                string token = Console.ReadLine();
                CreateIIdentity(token);
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                Ibuyer nameRebelCitizen = repositry.FirstOrDefault(x => x.Name == command);
                if (nameRebelCitizen != null)
                {
                    nameRebelCitizen.BuyFood();
                }
            }
            int sumFood = repositry.Sum(x => x.Food);
            Console.WriteLine(sumFood);
        }

        private void CreateIIdentity(string token)
        {
            string[] tokens = token.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Ibuyer buyer = null;
            if (tokens.Length == 4)
            {
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string id = tokens[2];
                string birthdate = tokens[3];
                buyer = new Citizen(name, age, id, birthdate);
            }
            else if(tokens.Length == 3)
            {
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string group = tokens[2];
                buyer = new Rebel(name, age, group);
            }
            this.repositry.Add(buyer);
        }
    }
}

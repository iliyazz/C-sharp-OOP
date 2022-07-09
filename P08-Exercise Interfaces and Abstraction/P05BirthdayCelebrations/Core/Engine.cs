
namespace BirthdayCelebrations.Core
{
    using BirthdayCelebrations.IO.Contracts;
    using BirthdayCelebrations.Models;
    using BirthdayCelebrations.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private List<IBirthdate> repositry;
        public Engine(IReader reader, IWriter writer)
        {
            this.repositry = new List<IBirthdate>();
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            string token = string.Empty;
            while ((token = Console.ReadLine()) != "End")
            {
                CreateIIdentity(token);
            }
            string year = Console.ReadLine();
            foreach (var obj in repositry)
            {
                if (obj.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(obj.Birthdate);
                }
            }
        }

        private void CreateIIdentity(string token)
        {
            string[] tokens = token.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            IBirthdate identity = null;
            if (tokens[0] == "Citizen")
            {
                string name = tokens[1];
                int age = int.Parse(tokens[2]);
                string id = tokens[3];
                string birthdate = tokens[4];
                identity = new Citizen(name, age, id, birthdate);

            }
            //else if (tokens[0] == "Robot")
            //{
            //    string model = tokens[1];
            //    string id = tokens[2];
            //    identity = new Robot(model, id);
            //}
            else if (tokens[0] == "Pet")
            {
                string name = tokens[1];
                string birthdate = tokens[2];
                identity = new Pet(name, birthdate);
            }
            else
            {
                return;
            }
            this.repositry.Add(identity);
        }
    }
}

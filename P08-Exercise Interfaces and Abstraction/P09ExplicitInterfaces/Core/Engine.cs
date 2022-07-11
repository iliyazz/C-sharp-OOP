
namespace ExplicitInterfaces.Core
{
    using ExplicitInterfaces.IO.Contracts;
    using ExplicitInterfaces.Models;
    using ExplicitInterfaces.Models.Contracts;
    using System;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Start()
        {
            string token = string.Empty;

            while ((token = Console.ReadLine()) != "End")
            {
                string name = token.Split()[0];
                string country = token.Split()[1];
                IPerson person = new Citizen(name, country);
                Console.WriteLine(person.GetName());
                IResident resident = new Citizen(name, country);
                Console.WriteLine(resident.GetName());
            }
        }
    }
}

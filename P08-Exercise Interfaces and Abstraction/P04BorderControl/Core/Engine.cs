
namespace BorderControl.Core
{
    using BorderControl.IO.Contracts;
    using BorderControl.Models;
    using BorderControl.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private List<IIdentity> repositry;
        public Engine(IReader reader, IWriter writer)
        {
            this.repositry = new List<IIdentity>();
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
            string fakeIdEndSymbols = Console.ReadLine();
            foreach (var obj in repositry)
            {
                if (obj.Id.EndsWith(fakeIdEndSymbols))
                {
                    Console.WriteLine(obj.Id);
                }
            }
        }

        private void CreateIIdentity(string token)
        {
            string[] tokens = token.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            IIdentity identity;
            if (tokens.Length == 3)
            {
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string id = tokens[2];
                identity = new Citizen(name, age, id);

            }
            else if (tokens.Length == 2)
            {
                string model = tokens[0];
                string id = tokens[1];
                identity = new Robot(model, id);
            }
            else
            {
                return;
            }
            this.repositry.Add(identity);
        }
    }
}

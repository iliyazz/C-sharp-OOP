namespace P03Raiding.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using IO.Contracts;
    using Factories;
    using Model;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private HeroFactory heroFactory;
        private Engine()
        {
            this.heroFactory = new HeroFactory();
        }
        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void start()
        {
            int number = int.Parse(reader.Readline());
            List<BaseHero> heroes = new List<BaseHero>();
            for (int i = 0; i < number; i++)
            {
                try
                {
                    string name = reader.Readline();
                    string type = reader.Readline();
                    BaseHero hero =this.heroFactory.CreateHero(name, type);
                    heroes.Add(hero);
                }
                catch (ArgumentException ex)
                {
                    i--;
                    writer.WriteLine(ex.Message);
                }
            }
            long bossPower = long.Parse(reader.Readline());
            long totalSumOfHeroesPower = 0;
            foreach (var hero in heroes)
            {
                writer.WriteLine(hero.CastAbility());
                totalSumOfHeroesPower += hero.Power;
            }
            if (totalSumOfHeroesPower >= bossPower)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }
        }
    }
}

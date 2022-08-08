namespace Easter.Models.Bunnies
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Dyes.Contracts;
    using Utilities.Messages;

    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private readonly IReadOnlyCollection<IDye> dyes;

        protected Bunny(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.dyes = new List<IDye>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }
                name = value;
            }
        }

        public int Energy
        {
            get => energy;
            protected set
            {
                if (value < 0)
                {
                    energy = 0;
                }
                energy = value;
            }
        }
        public ICollection<IDye> Dyes { get; }
        public abstract void Work();

        public void AddDye(IDye dye) => this.Dyes.Add(dye);
    }
}

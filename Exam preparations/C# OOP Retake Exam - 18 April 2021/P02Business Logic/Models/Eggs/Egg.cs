﻿namespace Easter.Models.Eggs
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public class Egg : IEgg
    {
        private string name;
        private int energyRequired;

        public Egg(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEggName);
                }
                name = value;
            }
        }

        public int EnergyRequired
        {
            get => energyRequired;
            private set
            {
                if (value < 0)
                {
                    this.energyRequired = 0;
                }
                else
                {
                    this.energyRequired = value;
                }
            }
        }
        public void GetColored()
        {
            if (this.EnergyRequired - 10 < 0)
            {
                this.EnergyRequired = 0;
            }
            else
            {
                this.EnergyRequired -= 10;
            }
        }

        public bool IsDone() => this.energyRequired == 0;
    }
}

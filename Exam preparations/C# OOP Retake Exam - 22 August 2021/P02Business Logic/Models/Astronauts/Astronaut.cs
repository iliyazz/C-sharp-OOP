namespace SpaceStation.Models
{
    using System;
    using System.Text;
    using Astronauts.Contracts;
    using Bags;
    using Bags.Contracts;
    using Utilities.Messages;

    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private IBag bag;

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.bag = new Backpack();
        }


        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }
                name = value;
            }
        }

        public double Oxygen
        {
            get => oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }
                oxygen = value;
            }
        }

        public virtual bool CanBreath => this.Oxygen >= 10.0;
        public IBag Bag => this.bag;
        public virtual void Breath()
        {
            if (this.Oxygen - 10 <= 0)
            {
                this.Oxygen = 0;
            }
            else
            {
                this.Oxygen -= 10;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Oxygen: {this.Oxygen}");
            string itemInBag = string.Join(", ", this.Bag.Items);
            if (itemInBag.Length == 0)
            {
                itemInBag = "none";
            }
            sb.AppendLine($"Bag items: {itemInBag}");
            return sb.ToString().TrimEnd();
        }
    }
}

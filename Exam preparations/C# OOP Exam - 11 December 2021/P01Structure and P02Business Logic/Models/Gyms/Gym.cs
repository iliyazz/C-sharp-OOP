namespace Gym.Models.Gyms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Athletes.Contracts;
    using Contracts;
    using Equipment.Contracts;
    using Utilities.Messages;

    public abstract class Gym : IGym
    {
        private string name;

        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Athletes = new List<IAthlete>();
            Equipment = new List<IEquipment>();
        }
        public string Name
        {
            get
            { 
                return this.name;
            } 
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                this.name = value;
            }
        }
        public int Capacity { get; private set; }

        public double EquipmentWeight
        {
            get
            {
                return this.Equipment.Select(x => x.Weight).Sum();
            }
        }
        public ICollection<IEquipment> Equipment { get; }
        public ICollection<IAthlete> Athletes { get; }
        public void AddAthlete(IAthlete athlete)
        {
            if (Athletes.Count >= Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            this.Athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return Athletes.Remove(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            if (Athletes.Count > 0)
            {
                sb.AppendLine($"Athletes: {string.Join(", ", Athletes.Select(x => x.FullName))}");
            }
            else
            {
                sb.AppendLine("Athletes: No athletes");
            }
            sb.AppendLine($"Equipment total count: {Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");
            return sb.ToString().TrimEnd();
        }
    }
}

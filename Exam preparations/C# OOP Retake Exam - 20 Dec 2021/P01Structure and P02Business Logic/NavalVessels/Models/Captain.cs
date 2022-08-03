namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Utilities.Messages;

    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        private readonly ICollection<IVessel> vessels;

        public Captain(string fullName)
        {
            this.FullName = fullName;
            this.vessels = new List<IVessel>();
            this.CombatExperience = 0;
        }


        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                this.fullName = value;
            }
        }
        public int CombatExperience
        {
            get => combatExperience;
            private set
            {
                if (value % 10 == 0)
                {
                    combatExperience = value;

                }
            }
        }

        public ICollection<IVessel> Vessels => vessels;
        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }
            if(vessels.All(x => x.Name != vessel.Name))
            {
                this.Vessels.Add(vessel);
            }
        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += 10;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.FullName} has {this.CombatExperience} combat experience and commands {this.Vessels.Count} vessels.");
            if (this.Vessels.Count != 0)
            {
                foreach (var ves in this.Vessels)
                {
                    sb.AppendLine(ves.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}

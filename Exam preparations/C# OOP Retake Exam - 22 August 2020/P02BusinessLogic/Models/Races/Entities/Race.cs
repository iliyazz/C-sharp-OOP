namespace EasterRaces.Models.Races.Entities
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Drivers.Contracts;
    using Utilities.Messages;

    public class Race : IRace
    {
        private string name;
        private int laps;
        private ICollection<IDriver> drivers;

      
        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            drivers = new List<IDriver>();
        }


        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }
                name = value;
            }
        }

        public int Laps
        {
            get => laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
                }
                laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => drivers as IReadOnlyCollection<IDriver>;
        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }

            if (!driver.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if (drivers.Contains(driver))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name,
                    this.Name));
            }
            drivers.Add(driver);
        }
    }
}

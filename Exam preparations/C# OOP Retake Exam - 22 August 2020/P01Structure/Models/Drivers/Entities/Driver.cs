namespace EasterRaces.Models.Drivers.Entities
{
    using System;
    using Cars.Contracts;
    using Contracts;
    using Utilities.Messages;

    public class Driver : IDriver
    {
        private string name;
        private ICar car;
        private int numberOfWins;
        private bool canParticipate = false;

        public Driver(string name)
        {
            Name = name;
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

        public ICar Car
        {
            get => car;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(ExceptionMessages.CarInvalid);
                }
                car = value;
            }
        }

        public int NumberOfWins
        {
            get => numberOfWins;
            private set => numberOfWins = value;
        }

        public bool CanParticipate
        {
            get => canParticipate;
            private set => canParticipate = value;
        }
        public void WinRace()
        {
            numberOfWins++;
        }

        public void AddCar(ICar car)
        {
            Car = car;
            canParticipate = true;
        }
    }
}

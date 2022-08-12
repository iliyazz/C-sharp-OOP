namespace EasterRaces.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Cars.Contracts;
    using Models.Cars.Entities;
    using Models.Drivers.Contracts;
    using Models.Drivers.Entities;
    using Models.Races.Contracts;
    using Models.Races.Entities;
    using Repositories.Contracts;
    using Repositories.Entities;
    using Utilities.Messages;

    public class ChampionshipController : IChampionshipController
    {
        private IRepository<IDriver> driverRepository;
        private IRepository<ICar> carRepository;
        private IRepository<IRace> raceRepository;
        public ChampionshipController()
        {
            driverRepository = new DriverRepository();
            carRepository = new CarRepository();
            raceRepository = new RaceRepository();
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = driverRepository.GetByName(driverName);
            if (driver != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            driver = new Driver(driverName);
            driverRepository.Add(driver);
            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            
            ICar car = null;
            if (carRepository.GetByName(model) != null)
            {
                throw new ArgumentException(ExceptionMessages.CarExists, model);
            }

            if (type == nameof(MuscleCar).Replace("Car", String.Empty))
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == nameof(SportsCar).Replace("Car", String.Empty))
            {
                car = new SportsCar(model, horsePower);
            }
            carRepository.Add(car);
            var typeOfCar = car.GetType().Name;
            return string.Format(OutputMessages.CarCreated, typeOfCar, model);
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = driverRepository.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            ICar car = carRepository.GetByName(carModel);
            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }
            driver.AddCar(car);
            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {

            IRace race = raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            IDriver driver = driverRepository.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            race.AddDriver(driver);
            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = raceRepository.GetByName(name);
            if (race != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            race = new Race(name, laps);
            raceRepository.Add(race);
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }



            List<IDriver> sortedDrivers =
                driverRepository.GetAll().OrderByDescending(p => p.Car.CalculateRacePoints(race.Laps)).ToList();
            var sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, sortedDrivers.First().Name, raceName))
                .AppendLine(string.Format(OutputMessages.DriverSecondPosition, sortedDrivers.Skip(1).First().Name, raceName))
                .AppendLine(string.Format(OutputMessages.DriverThirdPosition, sortedDrivers.Skip(2).First().Name, raceName));
            raceRepository.Remove(race);
            return sb.ToString().TrimEnd();

        }
    }
}

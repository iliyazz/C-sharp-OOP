namespace SpaceStation.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models;
    using Models.Astronauts;
    using Models.Astronauts.Contracts;
    using Models.Mission;
    using Models.Mission.Contracts;
    using Models.Planets;
    using Models.Planets.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly IRepository<IAstronaut> astronautRepository;
        private readonly IRepository<IPlanet> planetRepository;
        private readonly ICollection<string> exploredPlanets;

        public Controller()
        {
            astronautRepository = new AstronautRepository();
            planetRepository = new PlanetRepository();
            exploredPlanets = new List<string>();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else if(type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }
            astronautRepository.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }
        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            planetRepository.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronautRepository.FindByName(astronautName);
            if (astronaut == null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }
            astronautRepository.Remove(astronaut);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = planetRepository.FindByName(planetName);
            IMission mission = new Mission();
            var astronautForExploringPlanet = astronautRepository.Models.Where(o => o.Oxygen > 60).ToList();
            if (astronautForExploringPlanet.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }
            mission.Explore(planet, astronautForExploringPlanet);
            exploredPlanets.Add(planetName);
            return string.Format(OutputMessages.PlanetExplored, planetName,
                astronautForExploringPlanet.Count(o => o.Oxygen == 0));
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanets.Count} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var astronaut in astronautRepository.Models)
            {
                sb.AppendLine(astronaut.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}

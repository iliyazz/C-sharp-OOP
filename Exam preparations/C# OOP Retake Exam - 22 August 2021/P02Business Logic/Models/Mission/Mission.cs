namespace SpaceStation.Models.Mission
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Astronauts.Contracts;
    using Contracts;
    using Planets.Contracts;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                while (planet.Items.Count > 0 && astronaut.CanBreath)
                {
                    var takeItemFromPlanet = planet.Items.First();
                    astronaut.Bag.Items.Add(takeItemFromPlanet);
                    planet.Items.Remove(takeItemFromPlanet);
                    astronaut.Breath();
                    if (planet.Items.Count == 00 || astronaut.Oxygen == 0)
                    {
                        break;
                    }
                }

            }
        }
    }
}

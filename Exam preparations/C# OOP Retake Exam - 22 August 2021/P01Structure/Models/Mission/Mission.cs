namespace SpaceStation.Models.Mission
{
    using System.Collections.Generic;
    using Astronauts.Contracts;
    using Contracts;
    using Planets.Contracts;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            throw new System.NotImplementedException();
        }
    }
}

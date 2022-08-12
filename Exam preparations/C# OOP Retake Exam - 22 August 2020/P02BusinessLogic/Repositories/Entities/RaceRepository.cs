namespace EasterRaces.Repositories.Entities
{
    using System.Linq;
    using Models.Races.Entities;
    using EasterRaces.Models.Races.Contracts;

    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name) => this.Models.FirstOrDefault(x => x.Name == name);
    }
}

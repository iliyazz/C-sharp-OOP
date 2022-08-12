namespace EasterRaces.Repositories.Entities
{
    using System.Linq;
    using Models.Drivers.Entities;
    using EasterRaces.Models.Drivers.Contracts;

    public class DriverRepository : Repository<IDriver>
    {
        public override IDriver GetByName(string name) => this.Models.FirstOrDefault(x => x.Name == name);
    }
}

namespace EasterRaces.Repositories.Entities
{
    using System.Linq;
    using Models.Cars.Contracts;

    public class CarRepository : Repository<ICar>
    {
        public override ICar GetByName(string name) => this.Models.FirstOrDefault(n => n.Model == name);
    }
}

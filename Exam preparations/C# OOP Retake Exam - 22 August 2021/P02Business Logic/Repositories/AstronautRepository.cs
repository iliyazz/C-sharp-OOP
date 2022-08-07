namespace SpaceStation.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Astronauts.Contracts;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly ICollection<IAstronaut> models;

        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }


        public IReadOnlyCollection<IAstronaut> Models => (IReadOnlyCollection<IAstronaut>)models;
        public void Add(IAstronaut model) => models.Add(model);

        public bool Remove(IAstronaut model) => models.Remove(model);

        public IAstronaut FindByName(string name) => this.models.FirstOrDefault(n => n.Name == name);
    }
}

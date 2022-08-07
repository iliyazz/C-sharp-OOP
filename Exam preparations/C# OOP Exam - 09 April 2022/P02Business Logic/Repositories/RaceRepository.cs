namespace Formula1.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Contracts;

    public class RaceRepository : IRepository<IRace>
    {
        private readonly ICollection<IRace> models;

        public RaceRepository()
        {
            models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => (IReadOnlyCollection<IRace>)this.models;
        public void Add(IRace model) => this.models.Add(model);

        public bool Remove(IRace model) => this.models.Remove(model);

        public IRace FindByName(string name) => this.models.FirstOrDefault(n => n.RaceName == name);
    }
}

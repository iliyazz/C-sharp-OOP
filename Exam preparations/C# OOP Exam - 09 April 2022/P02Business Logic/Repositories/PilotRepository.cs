namespace Formula1.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Contracts;

    public class PilotRepository : IRepository<IPilot>
    {
        private readonly ICollection<IPilot> models;

        public PilotRepository()
        {
            models = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => (IReadOnlyCollection<IPilot>)this.models;
        public void Add(IPilot model) => this.models.Add(model);

        public bool Remove(IPilot model) => models.Remove(model);

        public IPilot FindByName(string name) => models.FirstOrDefault(n => n.FullName == name);
    }
}

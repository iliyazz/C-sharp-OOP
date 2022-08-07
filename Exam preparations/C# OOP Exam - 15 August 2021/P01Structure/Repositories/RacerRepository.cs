namespace CarRacing.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Racers.Contracts;
    using Utilities.Messages;

    public class RacerRepository : IRepository<IRacer>
    {
        private readonly ICollection<IRacer> models;
        public RacerRepository()
        {
            this.models = new List<IRacer>();
        }
        public IReadOnlyCollection<IRacer> Models { get => (IReadOnlyCollection<IRacer>)this.models; }
        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }
            this.models.Add(model);
        }

        public bool Remove(IRacer model) => this.models.Remove(model);

        public IRacer FindBy(string property) => this.models.FirstOrDefault(v => v.Username == property);
    }
}

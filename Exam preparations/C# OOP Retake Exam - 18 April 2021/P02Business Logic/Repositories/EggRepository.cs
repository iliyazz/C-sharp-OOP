namespace Easter.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Eggs.Contracts;

    public class EggRepository : IRepository<IEgg>
    {
        private readonly ICollection<IEgg> models;

        public EggRepository()
        {
            this.models = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => (IReadOnlyCollection<IEgg>)models;
        public void Add(IEgg model) => models.Add(model);

        public bool Remove(IEgg model)  => (models.Remove(model));

        public IEgg FindByName(string name) => models.FirstOrDefault(e => e.Name == name);
    }
}

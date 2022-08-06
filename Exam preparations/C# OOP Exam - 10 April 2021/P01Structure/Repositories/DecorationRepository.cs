namespace AquaShop.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Decorations.Contracts;

    public abstract class DecorationRepository : IRepository<IDecoration>
    {
        private readonly ICollection<IDecoration> models;

        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => (IReadOnlyCollection<IDecoration>)this.models;
        public void Add(IDecoration model) => this.models.Add(model);

        public bool Remove(IDecoration model) => this.models.Remove(model);

        public IDecoration FindByType(string type) => this.models.FirstOrDefault(x => x.GetType().Name == type);
    }
}

namespace Heroes.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Contracts;

    public class HeroRepository : IRepository<IHero>
    {
        private readonly ICollection<IHero> models;

        public HeroRepository()
        {
            models = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models { get => (IReadOnlyCollection<IHero>) models; }
        public void Add(IHero model)
        {
            models.Add(model);
        }

        public bool Remove(IHero model)
        {
            return models.Remove(model);
        }

        public IHero FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }
    }
}

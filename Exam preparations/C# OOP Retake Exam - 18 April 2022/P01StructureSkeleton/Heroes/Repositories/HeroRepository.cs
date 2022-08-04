namespace Heroes.Repositories
{
    using System.Collections.Generic;
    using Contracts;
    using Models.Contracts;

    public class HeroRepository : IRepository<IHero>
    {
        private readonly ICollection<IHero> models;

        public HeroRepository()
        {
            models = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models { get; }
        public void Add(IHero model)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(IHero model)
        {
            throw new System.NotImplementedException();
        }

        public IHero FindByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}

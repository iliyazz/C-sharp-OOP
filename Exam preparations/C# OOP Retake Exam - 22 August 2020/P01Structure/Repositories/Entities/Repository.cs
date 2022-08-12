namespace EasterRaces.Repositories.Entities
{
    using System.Collections.Generic;
    using Contracts;

    public abstract class Repository<T> : IRepository<T> where T :class

    {
        private ICollection<T> models;

        protected Repository()
        {
            models = new List<T>();
        }
        public ICollection<T> Models => models;

        public abstract T GetByName(string name);

        public IReadOnlyCollection<T> GetAll() => this.models as IReadOnlyCollection<T>;

        public void Add(T model) => models.Add(model);

        public bool Remove(T model) => models.Remove(model);
    }
}

namespace Heroes.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly ICollection<IWeapon> models;

        public WeaponRepository()
        {
            models = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models { get => (IReadOnlyCollection<IWeapon>)models; }
        public void Add(IWeapon model)
        {
            models.Add(model);
        }

        public bool Remove(IWeapon model)
        {
           return models.Remove(model);
        }

        public IWeapon FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }
    }
}

namespace Heroes.Repositories
{
    using System.Collections.Generic;
    using Contracts;
    using Models.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly ICollection<IWeapon> models;

        public WeaponRepository()
        {
            models = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models { get; }
        public void Add(IWeapon model)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(IWeapon model)
        {
            throw new System.NotImplementedException();
        }

        public IWeapon FindByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}

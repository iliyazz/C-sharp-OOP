namespace CarRacing.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Cars.Contracts;
    using Utilities.Messages;

    public class CarRepository : IRepository<ICar>
    {
        private readonly ICollection<ICar> models;

        public CarRepository()
        {
            this.models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models { get => (IReadOnlyCollection<ICar>)this.models; }
        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }
            this.models.Add(model);
        }

        public bool Remove(ICar model) => this.models.Remove(model);

        public ICar FindBy(string property) => this.models.FirstOrDefault(v => v.VIN == property);
    }
}

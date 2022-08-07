namespace Formula1.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Contracts;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly ICollection<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            models = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => (IReadOnlyCollection<IFormulaOneCar>)this.models;
        public void Add(IFormulaOneCar car) => models.Add(car);

        public bool Remove(IFormulaOneCar car) => models.Remove(car);

        public IFormulaOneCar FindByName(string name) => models.FirstOrDefault(n => n.Model == name);
    }
}

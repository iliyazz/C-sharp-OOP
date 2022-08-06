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
        public void Add(IFormulaOneCar model) => models.Add(model);

        public bool Remove(IFormulaOneCar model) => models.Remove(model);

        public IFormulaOneCar FindByName(string name) => models.FirstOrDefault(n => n.Model == name);
    }
}

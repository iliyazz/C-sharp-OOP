namespace NavalVessels.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Contracts;

    public class VesselRepository : IRepository<IVessel>
    {
        private readonly ICollection<IVessel> models;
        public VesselRepository()
        {
            this.models = new List<IVessel>();
        }
        public IReadOnlyCollection<IVessel> Models
        {
            get { return (IReadOnlyCollection<IVessel>)models; }
        }
        public void Add(IVessel model)
        {

            models.Add(model);
        }
        public bool Remove(IVessel model)
        {
            return models.Remove(model);
        }
        public IVessel FindByName(string name)
        {
            var vessel = models.FirstOrDefault(x => x.Name == name);
            return vessel;
        }
    }
}

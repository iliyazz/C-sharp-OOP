namespace Gym.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Equipment;
    using Models.Equipment.Contracts;

    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> models;

        public EquipmentRepository()
        {
            this.models = new List<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models {
            get
            {
                return this.models.AsReadOnly();
            }
        }
        public void Add(IEquipment model)
        {
            models.Add(model);
        }

        public bool Remove(IEquipment model)
        {
            return models.Remove(model);
        }

        public IEquipment FindByType(string type)
        {
            return models.FirstOrDefault(x => x.GetType().Name == type);
        }
    }
}

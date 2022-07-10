namespace MilitaryElite.IO.Models.Contracts
{
    using System.Collections.Generic;
    public interface IEngineer : ISpecialisedSoldier
    {
        public IReadOnlyCollection<IRepair> Repairs { get; }

    }
}

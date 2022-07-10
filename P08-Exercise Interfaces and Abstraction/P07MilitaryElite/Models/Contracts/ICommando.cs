using System.Collections.Generic;

namespace MilitaryElite.IO.Models.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        public IReadOnlyCollection<IMission> Missions { get; }
    }
}

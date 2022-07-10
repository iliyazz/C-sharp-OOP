namespace MilitaryElite.IO.Models.Contracts
{
    using System.Collections.Generic;
    public interface ILieutenantGeneral : IPrivate
    {
        public IReadOnlyCollection<ISoldier> Privates { get;}
    }
}

namespace MilitaryElite.IO.Models.Contracts
{
    using MilitaryElite.Enum;
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }

    }
}

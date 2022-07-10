namespace MilitaryElite.IO.Models.Contracts
{
    public interface IRepair
    {
        string PartName { get; }
        int HoursWorked { get; }
    }
}

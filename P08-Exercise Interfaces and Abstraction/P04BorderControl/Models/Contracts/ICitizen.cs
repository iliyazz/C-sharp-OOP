namespace BorderControl.Models.Contracts
{
    public interface ICitizen : IIdentity
    {
        string Name { get; }
        int Age { get; }
    }
}

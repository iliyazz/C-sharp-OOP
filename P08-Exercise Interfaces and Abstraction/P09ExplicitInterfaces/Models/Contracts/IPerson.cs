namespace ExplicitInterfaces.Models.Contracts
{
    public interface IPerson
    {
        public string Name { get; }
        public string Country { get; }
        public string GetName();
    }
}

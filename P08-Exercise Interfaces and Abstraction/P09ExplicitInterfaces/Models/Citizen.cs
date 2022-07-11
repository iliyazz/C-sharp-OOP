namespace ExplicitInterfaces.Models
{
    using ExplicitInterfaces.Models.Contracts;

    public class Citizen : IResident, IPerson
    {
        public string Name
        { 
            get;
            private set;
        }

        public string Country
        {
            get;
            private set;
        }

        public Citizen(string name, string country)
        {
            Name = name;
            Country = country;
        }

        public string GetName()
        {
            return this.Name;
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }

    }
}

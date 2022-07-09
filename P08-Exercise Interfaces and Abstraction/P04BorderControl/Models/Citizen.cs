namespace BorderControl.Models
{
    
    using BorderControl.Models.Contracts;

    public class Citizen : ICitizen
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; set; }

        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
    }
}

namespace BirthdayCelebrations.Models
{
    
    using BirthdayCelebrations.Models.Contracts;

    public class Citizen : ICitizen
    {
        public string NameModel { get; private set; }
        public int Age { get; private set; }
        public string Identity { get; set; }
        public string Birthdate { get; private set; }



        public Citizen(string name, int age, string id, string birthdate)
        {
            this.NameModel = name;
            this.Age = age;
            this.Identity = id;
            this.Birthdate = birthdate;
        }
    }
}

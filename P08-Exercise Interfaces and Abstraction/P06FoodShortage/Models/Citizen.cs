namespace FoodShortage.Models
{
    using Contracts;
    public class Citizen : ICitizen
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Identity { get; set; }
        public string Birthdate { get; private set; }
        public int Food { get; private set; }
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Identity = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }
        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}

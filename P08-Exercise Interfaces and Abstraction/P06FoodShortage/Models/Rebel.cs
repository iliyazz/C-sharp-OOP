
namespace FoodShortage.Models
{
    using Contracts;
    public class Rebel : IRebel
    {

        public string Group { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Food { get; private set; }

        public Rebel(string nameModel, int age, string group)
        {
            Group = group;
            Name = nameModel;
            Age = age;
            Food = 0;
        }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}

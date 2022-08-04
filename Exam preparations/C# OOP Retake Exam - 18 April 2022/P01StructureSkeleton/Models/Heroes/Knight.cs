namespace Heroes.Models.Heroes
{
    using Contracts;

    public class Knight : Hero, IHero
    {
        public Knight(string name, int health, int armour)
            : base(name, health, armour)
        {
        }
    }
}

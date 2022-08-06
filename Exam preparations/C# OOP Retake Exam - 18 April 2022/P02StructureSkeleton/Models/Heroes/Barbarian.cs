namespace Heroes.Models.Heroes
{
    using Contracts;

    public class Barbarian : Hero, IHero
    {
        public Barbarian(string name, int health, int armour)
            : base(name, health, armour)
        {
        }
    }
}

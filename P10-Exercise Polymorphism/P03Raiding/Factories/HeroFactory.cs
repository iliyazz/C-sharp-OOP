namespace P03Raiding.Factories
{
    using System;
    using Model;
    using Enum;
    public class HeroFactory
    {
        public BaseHero CreateHero(string name, string type)
        {
            BaseHero hero = null;
            if (type == nameof(HeroType.Druid))
            {
                hero = new Druid(name);
            }
            else if (type == nameof(HeroType.Paladin))
            {
                hero = new Paladin(name);
            }
            else if (type == nameof(HeroType.Rogue))
            {
                hero = new Rogue(name);
            }
            else if (type == nameof(HeroType.Warrior))
            {
                hero = new Warrior(name);
            }
            else if(hero == null)
            {
                throw new ArgumentException("Invalid hero!");
            }
            return hero;
        }
    }
}

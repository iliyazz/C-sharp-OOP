namespace Heroes.Models.Weapons
{
    using Contracts;

    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;

        public Weapon(string name, int durability)
        {
            Name = name;
            Durability = durability;
        }
        public string Name { get; }
        public int Durability { get; }
        public abstract int DoDamage();
    }
}

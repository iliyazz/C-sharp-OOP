namespace Heroes.Models.Heroes
{
    using Contracts;

    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private bool isAlive;
        IWeapon weapon;

        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public string Name { get; }
        public int Health { get; }
        public int Armour { get; }
        public IWeapon Weapon { get; }
        public bool IsAlive { get; }
        public void TakeDamage(int points)
        {
            throw new System.NotImplementedException();
        }

        public void AddWeapon(IWeapon weapon)
        {
            throw new System.NotImplementedException();
        }
    }
}

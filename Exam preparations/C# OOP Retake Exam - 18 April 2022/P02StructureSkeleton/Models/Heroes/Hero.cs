namespace Heroes.Models.Heroes
{
    using System;
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

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int Health
        {
            get => health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                health = value;
            }
        }

        public int Armour
        {
            get => armour;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                armour = value;
            }
        }

        public IWeapon Weapon
        {
            get => weapon;
            private set
            {
                if (weapon == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }
            }
        }

        public bool IsAlive => this.Health > 0;

        public void TakeDamage(int points)
        {
            if (Armour > points)
            {
                Armour -= points;
            }
            else if(Armour > 0)
            {
                points -= Armour;
                Armour = 0;
            }
            if (Health > points && Armour == 0)
            {
                Health -= points;
            }
            else if(Health <= points && armour == 0)
            {
                Health = 0;
            }


        }

        public void AddWeapon(IWeapon weapon) => this.weapon = weapon;
    }
}

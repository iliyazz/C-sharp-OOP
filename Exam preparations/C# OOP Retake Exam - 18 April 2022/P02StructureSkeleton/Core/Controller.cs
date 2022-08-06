namespace Heroes.Core
{
    using Contracts;
    using Models.Heroes;
    using Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Heroes.Repositories;
    using Heroes.Models.Weapons;
    using Heroes.Models.Map;
    using System.Linq;

    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;
        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero hero  = null;
            if (type == typeof(Knight).Name)
            {
                if (heroes.FindByName(name) != null)
                {
                    throw new InvalidOperationException($"The hero {name} already exists.");
                }
                hero = new Knight(name, health, armour);
                heroes.Add(hero);
                return $"Successfully added Sir {name} to the collection.";
            }
            else if (type == typeof(Barbarian).Name)
            {
                if (heroes.FindByName(name) != null)
                {
                    throw new InvalidOperationException($"The hero {name} already exists.");
                }
                hero = new Barbarian(name, health, armour);
                heroes.Add(hero);
                return $"Successfully added Barbarian {name} to the collection.";
            }
            else
            {
                throw new InvalidOperationException("Invalid hero type.");
            }
        }


        public string CreateWeapon(string type, string name, int durability)
        {
            IWeapon weapon = null;
            if (type == typeof(Claymore).Name)
            {
                weapon = new Claymore(name, durability);
                if (weapons.FindByName(name) != null)
                {
                    throw new InvalidOperationException($"The weapon {name} already exists.");
                }
                weapons.Add(weapon);
                return $"A {type.ToLower()} {weapon.Name} is added to the collection.";
            }
            else if (type == typeof(Mace).Name)
            {
                weapon = new Mace(name, durability);
                if (weapons.FindByName(name) != null)
                {
                    throw new InvalidOperationException($"The weapon {name} already exists.");
                }
                weapons.Add(weapon);
                return $"A {type.ToLower()} {weapon.Name} is added to the collection.";
            }
            else
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }
        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            var hero = heroes.FindByName(heroName);
            var weapon = weapons.FindByName(weaponName);
            
            if (heroes.FindByName(heroName) == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            if (weapons.FindByName(weaponName) == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }
            
            if (hero.Weapon == null)
            {
                hero.AddWeapon(weapon);
                weapons.Remove(weapon);
            }
            else
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }
            string weaponType = weapon is Claymore ? nameof(Claymore) : nameof(Mace).ToLower();
            return $"Hero {heroName} can participate in battle using a {weaponType}.";


        }
        public string StartBattle()
        {
            var map = new Map();
            var result = map.Fight(heroes.Models as ICollection<IHero>);
            return result;
        }

        public string HeroReport()
        {
            var orderedHeroes = heroes.Models.OrderBy(t => t.GetType().Name).ThenByDescending(h => h.Health).ThenBy(n => n.Name);
            var sb = new StringBuilder();
            foreach (var hero in orderedHeroes)
            {
                sb.AppendLine($"{hero.GetType().Name }: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");
                string armedOrNotString = hero.Weapon != null ? hero.Weapon.Name : "Unarmed";
                sb.AppendLine($"--Weapon: {armedOrNotString}");
            }
            return sb.ToString().TrimEnd();
        }

    }
}

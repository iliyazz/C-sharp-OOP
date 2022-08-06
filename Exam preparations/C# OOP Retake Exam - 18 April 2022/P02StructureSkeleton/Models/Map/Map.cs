namespace Heroes.Models.Map
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Heroes;

    public class Map : IMap
    {
        private readonly ICollection<IHero> players;

        public Map()
        {
            players = new List<IHero>();
        }

        public string Fight(ICollection<IHero> players)
        {
            var knights = new List<Knight>();
            var barbarians = new List<Barbarian>();
           
            foreach (var player in players)
            {

                if (player.IsAlive && player.Weapon != null)
                {
                    if (player is Knight knight)
                    {
                        knights.Add(knight);
                    }
                    else if (player is Barbarian barbarian)
                    {
                        barbarians.Add(barbarian);
                    }
                }
                
            }
            int knightsStartCount = knights.Count;
            int barbariansStartCount = barbarians.Count;

            while (knights.Any(x => x.IsAlive && barbarians.Any(x => x.IsAlive)))
            {

                
                
                foreach (var knight in knights)
                {
                    foreach (var barbarian in barbarians)
                    {
                        if (knight.IsAlive && knight.Weapon != null && barbarian.IsAlive)
                        {
                            barbarian.TakeDamage(knight.Weapon.DoDamage());
                        }
                    }
                }

                foreach (var barbarian in barbarians)
                {
                    foreach (var knight in knights)
                    {
                        if (knight.IsAlive && barbarian.Weapon != null && barbarian.IsAlive)
                        {
                            knight.TakeDamage(barbarian.Weapon.DoDamage());
                        }
                    }
                }
            }
            string result = string.Empty;
            if (knights.Any(x => x.IsAlive))
            {
                result = $"The knights took {knightsStartCount - knights.Where(x => x.IsAlive == true).ToList().Count} casualties but won the battle.";
            }
            else if (barbarians.Any((x => x.IsAlive)))
            {
                result =
                    $"The barbarians took {barbariansStartCount - barbarians.Where(x => x.IsAlive == true).ToList().Count} casualties but won the battle.";
            }
            return result;
        }
    }
}

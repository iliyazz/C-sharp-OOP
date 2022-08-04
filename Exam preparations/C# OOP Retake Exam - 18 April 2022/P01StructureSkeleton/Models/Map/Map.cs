namespace Heroes.Models.Map
{
    using System.Collections.Generic;
    using Contracts;

    public class Map : IMap
    {
        private readonly ICollection<IHero> players;
        public string Fight(ICollection<IHero> players)
        {
            throw new System.NotImplementedException();
        }
    }
}

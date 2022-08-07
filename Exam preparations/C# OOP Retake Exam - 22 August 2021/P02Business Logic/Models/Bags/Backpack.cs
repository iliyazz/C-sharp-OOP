namespace SpaceStation.Models.Bags
{
    using System.Collections.Generic;
    using Contracts;

    public class Backpack : IBag
    {
        private readonly ICollection<string> items;


        public Backpack()
        {
            this.items = new List<string>();
        }

        public ICollection<string> Items => this.items;
    }
}

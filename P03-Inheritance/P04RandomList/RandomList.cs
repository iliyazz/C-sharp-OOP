using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        Random rand = new Random();
        public string RandomString()
        {
            if (this.Count == 0)
            {
                return null;
            }
            var index = rand.Next(0, this.Count);
            string element = this[index];
            this.RemoveAt(index);
            return element;
        }
    }
}

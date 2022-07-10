namespace CollectionHierarchy.Models
{
    using CollectionHierarchy.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MyList<T> : IMyList<T>
    {
        private readonly IList<T> data;
        public MyList()
        {
            this.data = new List<T>();
        }
        public int Used => this.data.Count;

        public int Add(T item)
        {
            this.data.Insert(0, item);
            return 0;
        }

        public T Remove()
        {
            T item = this.data.FirstOrDefault();
            if (item != null)
            {
                this.data.Remove(item);
            }
            return item;
        }
    }
}

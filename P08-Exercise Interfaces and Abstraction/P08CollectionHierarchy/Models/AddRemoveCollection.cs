

namespace CollectionHierarchy.Models
{
    using CollectionHierarchy.Models.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class AddRemoveCollection<T> : IAddRemoveCollection<T>
    {

        private IList<T> data;

        public AddRemoveCollection()
        {
            this.data = new List<T>();
        }

        public int Add(T item)
        {
            this.data.Insert(0, item);
            return 0;
        }

        public T Remove()
        {
            T item = this.data.LastOrDefault();
            if (item != null)
            {
                this.data.Remove(item);
            }
            return item;
        }
    }
}

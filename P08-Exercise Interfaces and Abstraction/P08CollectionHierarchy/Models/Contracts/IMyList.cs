namespace CollectionHierarchy.Models.Contracts
{
    public interface IMyList<T> :IAddRemoveCollection<T>
    {
        public int Used { get; }
    }
}

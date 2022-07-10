namespace FoodShortage.Models.Contracts
{
    public interface IRebel : IAge, Ibuyer
    {
        public string Group { get; }
    }
}

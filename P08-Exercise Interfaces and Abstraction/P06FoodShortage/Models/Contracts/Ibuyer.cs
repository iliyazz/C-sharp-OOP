namespace FoodShortage.Models.Contracts
{
    public interface Ibuyer
    {
        public string Name { get; }
        public int Food { get; }
        void BuyFood();
    }
}

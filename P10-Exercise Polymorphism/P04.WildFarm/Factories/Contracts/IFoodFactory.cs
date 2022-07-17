namespace WildFarm.Factories.Contracts
{
    using Models.Foods;
    public interface IFoodFactory
    {
        Food CreateFood(string type, int quantity);
    }
}

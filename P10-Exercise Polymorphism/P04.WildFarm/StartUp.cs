namespace WildFarm
{
    using Core;
    using Factories;
    using Factories.Contracts;
    using IO;
    using IO.Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IFoodFactory foodFactory = new FoodFactory();
            IAnimalFactory animalFactory = new AnimalFactory();
            IEngine engine = new Engine(foodFactory, animalFactory, reader, writer);
            engine.Start();
        }
    }
}

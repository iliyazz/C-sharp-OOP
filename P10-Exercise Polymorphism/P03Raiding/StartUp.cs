namespace P03Raiding
{
    using Core;
    using IO;
    using IO.Contracts;
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            Engine engine = new Engine(reader, writer);
            engine.start();
        }
    }
}

namespace BorderControl
{
    using IO;
    using Core;
    using IO.Contracts;
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(reader, writer);

            engine.Start();
        }
    }
}

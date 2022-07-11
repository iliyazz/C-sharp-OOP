namespace ExplicitInterfaces
{
    using ExplicitInterfaces.Core;
    using ExplicitInterfaces.IO;
    using ExplicitInterfaces.IO.Contracts;
    using System;
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

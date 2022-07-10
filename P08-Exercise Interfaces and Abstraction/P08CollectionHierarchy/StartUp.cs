namespace CollectionHierarchy
{
    using CollectionHierarchy.Core;
    using CollectionHierarchy.IO;
    using CollectionHierarchy.IO.Contracts;
    using System;
    public class Program
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

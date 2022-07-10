

namespace CollectionHierarchy.IO
{
    using System;
    using CollectionHierarchy.IO.Contracts;
    public class ConsoleReader : IReader
    {
        public string Readline()
        {
            return Console.ReadLine();
        }
    }
}

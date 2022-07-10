

namespace MilitaryElite.IO
{
    using System;
    using MilitaryElite.IO.Contracts;
    public class ConsoleReader : IReader
    {
        public string Readline()
        {
            return Console.ReadLine();
        }
    }
}

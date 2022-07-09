

namespace BirthdayCelebrations.IO
{
    using System;
    using BirthdayCelebrations.IO.Contracts;
    public class ConsoleReader : IReader
    {
        public string Readline()
        {
            return Console.ReadLine();
        }
    }
}

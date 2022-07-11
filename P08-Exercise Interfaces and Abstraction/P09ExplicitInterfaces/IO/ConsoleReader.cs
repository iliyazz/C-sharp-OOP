namespace ExplicitInterfaces.IO
{
    using System;
    using ExplicitInterfaces.IO.Contracts;
    public class ConsoleReader : IReader
    {
        public string Readline()
        {
            return Console.ReadLine();
        }
    }
}

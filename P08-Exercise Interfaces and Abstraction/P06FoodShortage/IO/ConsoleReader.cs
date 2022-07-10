

namespace FoodShortage.IO
{
    using System;
    using FoodShortage.IO.Contracts;
    public class ConsoleReader : IReader
    {
        public string Readline()
        {
            return Console.ReadLine();
        }
    }
}

﻿namespace P03Raiding.IO
{
    using System;
    using Contracts;
    public class ConsoleReader : IReader
    {
        public string Readline()
        {
            return Console.ReadLine();
        }
    }
}

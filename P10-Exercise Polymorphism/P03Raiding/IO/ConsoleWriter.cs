namespace P03Raiding.IO
{
    using System;
    using Contracts;

    public class ConsoleWriter : IWriter
    {
        public void Write(string value)
        {
            Console.Write(value);
        }

        void IWriter.WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}

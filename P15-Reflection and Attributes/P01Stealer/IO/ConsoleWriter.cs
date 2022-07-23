namespace Stealer.IO
{
    using System;
    using Contracts;

    public class ConsoleWriter : IWriter
    {
        public void Writ(string value)
        {
            Console.Write(value);
            ;
        }

        public void Writeline(string value)
        {
            Console.WriteLine(value);
            ;
        }
    }
}

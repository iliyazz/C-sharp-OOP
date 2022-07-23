namespace Stealer
{
    using System;
    using IO;
    using IO.Contracts;
    using Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            //string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            string result = spy.AnalyzeAccessModifiers("Stealer.Hacker");
            IWriter writer = new ConsoleWriter();
            writer.WriteLine(result);
        }
    }
}

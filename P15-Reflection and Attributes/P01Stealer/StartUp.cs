namespace Stealer
{
    using IO;
    using IO.Contracts;
    using Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            IWriter writer = new ConsoleWriter();
            writer.Writeline(result);
        }
    }
}

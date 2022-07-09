
namespace Telephony
{
    using IO.Contracts;
    using IO;
    using Core;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(reader, writer);
            engine.Start();
        }
    }
}

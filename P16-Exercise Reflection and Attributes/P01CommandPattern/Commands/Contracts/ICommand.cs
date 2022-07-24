namespace CommandPattern.Commands.Contracts
{
    public interface ICommand
    {
        public string Execute(string[] args);
    }
}

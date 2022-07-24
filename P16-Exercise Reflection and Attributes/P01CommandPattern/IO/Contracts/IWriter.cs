namespace CommandPattern.IO.Contracts
{
    public interface IWriter
    {
        public void Write(string value);
        public void WriteLine(string value);
    }
}

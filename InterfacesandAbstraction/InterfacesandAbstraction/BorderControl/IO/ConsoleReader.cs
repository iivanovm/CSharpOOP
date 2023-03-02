using BorderControl.IO.interfaces;

namespace BorderControl.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}

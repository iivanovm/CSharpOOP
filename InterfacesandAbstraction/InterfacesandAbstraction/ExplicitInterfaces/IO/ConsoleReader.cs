using ExplicitInterfaces.IO.interfaces;

namespace ExplicitInterfaces.IO;

public class ConsoleReader : IReader
{
    public string ReadLine() => Console.ReadLine();
}

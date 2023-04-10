using Vehicles.IO.interfaces;

namespace Vehicles.IO;

public class ConsoleReader : IReader
{
    public string ReadLine() => Console.ReadLine();
}

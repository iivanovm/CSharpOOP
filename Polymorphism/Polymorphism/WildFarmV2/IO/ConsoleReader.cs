using WildFarm.IO.interfaces;

namespace WildFarm.IO;

public class ConsoleReader : IReader
{
    public string ReadLine() => Console.ReadLine();
}

namespace CollectionHierarchy;
using CollectionHierarchy.IO.interfaces;


public class ConsoleReader : IReader
{
    public string Read() => Console.ReadLine();
}

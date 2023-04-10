using CollectionHierarchy.Engine.interfaces;
using CollectionHierarchy.IO;
using CollectionHierarchy.IO.interfaces;
using CollectionHierarchy.Engine;
using CollectionHierarchy;

public class StartUp
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IEngines engines = new Engine();
        engines.Run(reader, writer);
    }
}
namespace ExplicitInterfaces;
using IO.interfaces;
using IO;
using Core;
using ExplicitInterfaces.Core.interfaces;

public class StartUp
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IEngine engine= new Engine();
        engine.run(reader, writer);
    }
}

namespace Vehicles;
using IO.interfaces;
using IO;
using Core.interfaces;
using Core;

public class StartUp
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IEngine engine = new Engine ();
        engine.Start(reader, writer);

    }
}
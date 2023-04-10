using Raiding.Core;
using Raiding.Core.interfaces;
using Raiding.IO;
using Raiding.IO.interfaces;


public class StartUp
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IEngine engine = new Engine();
        engine.Start(reader, writer);
    }
}

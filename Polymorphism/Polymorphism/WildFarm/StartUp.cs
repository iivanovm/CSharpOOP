using WildFarm.Core;
using WildFarm.Core.interfaces;
using WildFarm.IO;
using WildFarm.IO.interfaces;
using WildFarm.Models;
using WildFarm.Models.Struct;

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
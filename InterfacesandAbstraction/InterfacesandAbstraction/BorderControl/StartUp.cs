namespace BorderControl;

using Core.Interface;
using IO;
using IO.interfaces;
public class StartUp
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IEngine engine = new Engine(reader, writer);
        engine.Run();
    }
}

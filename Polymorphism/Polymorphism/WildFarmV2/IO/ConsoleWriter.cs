using WildFarm.IO.interfaces;

namespace WildFarm.IO;

public class ConsoleWriter : IWriter
{
    public void Write(string line)=>Console.Write(line);

    public void WriteLine(string line)=>Console.WriteLine(line);
}

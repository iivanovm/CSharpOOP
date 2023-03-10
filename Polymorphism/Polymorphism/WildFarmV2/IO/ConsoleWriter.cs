using WildFarm.IO.interfaces;
using WildFarm.Models.interfaces;

namespace WildFarm.IO;

public class ConsoleWriter : IWriter
{
    public void Write(string line)=>Console.Write(line);

    public void WriteLine(string line)=>Console.WriteLine(line);

    public void WriteToJson(ICollection<IAnimal> animals)
    {
        throw new NotImplementedException();
    }
}

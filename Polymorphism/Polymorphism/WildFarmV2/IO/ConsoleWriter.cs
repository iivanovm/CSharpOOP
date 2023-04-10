using WildFarmV2.IO.interfaces;
using WildFarmV2.Models.interfaces;

namespace WildFarmV2.IO;

public class ConsoleWriter : IWriter
{
    public void Write(string line)=>Console.Write(line);

    public void WriteLine(string line)=>Console.WriteLine(line);

    public void WriteToJson(ICollection<IAnimal> animals)
    {
        throw new NotImplementedException();
    }
}

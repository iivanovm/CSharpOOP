using WildFarm.Models.interfaces;

namespace WildFarm.IO.interfaces;

public interface IWriter
{
    void WriteLine(string line);
    void Write(string line);

    void WriteToJson(ICollection<IAnimal> animals);
}

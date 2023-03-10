using WildFarmV2.Models.interfaces;

namespace WildFarmV2.IO.interfaces;

public interface IWriter
{
    void WriteLine(string line);
    void Write(string line);

    void WriteToJson(ICollection<IAnimal> animals);
}

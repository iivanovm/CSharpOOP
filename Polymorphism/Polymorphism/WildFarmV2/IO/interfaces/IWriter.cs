namespace WildFarmV2.IO.interfaces;
using WildFarmV2.Models.interfaces;


public interface IWriter
{
    void WriteLine(string line);
    void Write(string line);
    void WriteToJson(ICollection<IAnimal> animals);
}

using WildFarmV2.Models.interfaces;

namespace WildFarmV2.IO.interfaces;

public interface IWriterJson
{
    void WriteToJson(ICollection<IAnimal> animals,string fileName);
}

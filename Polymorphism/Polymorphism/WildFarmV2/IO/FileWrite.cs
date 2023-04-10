using Newtonsoft.Json;
using WildFarmV2.IO.interfaces;
using WildFarmV2.Models.interfaces;

namespace WildFarmV2.IO;

public class FileWrite : IWriter
{

    private string fileName;
    

    public FileWrite(string fileName)
    {
        this.fileName = fileName;
    }

    public void Write(string line)
    {
        
    }

    public void WriteLine(string line)
    {
        using (StreamWriter wr= new StreamWriter(fileName,true)) 
        { 
            wr.WriteLine(line); 
        }
    }

    public void WriteToJson(ICollection<IAnimal> animals)
    {
        using (StreamWriter wr = new StreamWriter(fileName, true))
        {
            wr.Write(JsonConvert.SerializeObject(animals, Formatting.Indented));
        }
    }
}

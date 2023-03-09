using WildFarm.IO.interfaces;

namespace WildFarmV2.IO;

public class FileWrite:IWriter
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
        using (StreamWriter wr = new StreamWriter(fileName, true))
        {
            wr.WriteLine(line);
        }
    }
}

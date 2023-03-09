using System.Collections;
using System.Collections.Generic;
using WildFarm.IO.interfaces;

namespace WildFarm.IO;

public class FileReader : IReader
{


    private string fileName ;
    public FileReader(string fileName)
    {
        this.fileName = fileName;
    }
    public string ReadLine()
    {
        string result=string.Empty;
        if (File.Exists(fileName))
        {
            string[] data = File.ReadAllLines(fileName);
            result = string.Join(" ", data);
        }
        //using (StreamReader sr = File.OpenText(fileName))
        //{
        //    string s = String.Empty;
        //    while ((s = sr.ReadLine()) != null)
        //    {
        //        result = s;
        //    }
        //}
        return result;
    }


}

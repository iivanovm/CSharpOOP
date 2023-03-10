using System.Collections;
using System.Collections.Generic;
using WildFarm.IO.interfaces;

namespace WildFarm.IO;

public class FileReader : IReader
{
    private string fileName;

    Queue<string> command=new Queue<string>();

    public FileReader(string fileName)
    {
        this.fileName = fileName;
        textProcess(fileName);
    }

    public string ReadLine()
    {
        string line="";    
        while(command.Any())
        {
           line=command.Dequeue();
            
            break;
        }
        
        return line;
    }


    void textProcess(string fileName)
    {
        string lineOfText;
        var filestream = new System.IO.FileStream(fileName,
                                          System.IO.FileMode.Open,
                                          System.IO.FileAccess.Read,
                                          System.IO.FileShare.ReadWrite);
        var file = new System.IO.StreamReader(filestream, System.Text.Encoding.UTF8, true, 128);
        Queue<string> rawData = new Queue<string>();
        while ((lineOfText = file.ReadLine()) != null)
        {
           //using(StreamWriter wr = new StreamWriter(fileName))
            //{
                command.Enqueue(lineOfText);
           // }
        }
        
    }


}

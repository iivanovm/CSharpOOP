using RobotService.IO.Contracts;
using System.IO;

namespace RobotService.Models.Models.Supplement;

public abstract partial class Supplement
{
    public class FileWriter : IWriter
    {
        string path = "../../../output.txt";
        public void Write(string message)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.Write(message);
            }
        }

        public void WriteLine(string message)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
            }
        }
    }

}

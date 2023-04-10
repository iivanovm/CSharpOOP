using BorderControl.IO.interfaces;

namespace BorderControl.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string texName)
        {
            Console.Write(texName);
        }

        public void WriteLine(string texName)
        {
            Console.WriteLine(texName);
        }
    }
}

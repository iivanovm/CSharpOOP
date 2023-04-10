using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string varName = Console.ReadLine();
            int varAge = int.Parse(Console.ReadLine());
            Child child = new Child(varName, varAge);
            Console.WriteLine(child);
        }
    }
}
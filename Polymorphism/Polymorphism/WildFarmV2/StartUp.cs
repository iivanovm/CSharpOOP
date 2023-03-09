using System.Diagnostics.Metrics;
using WildFarm;
using WildFarm.Core;
using WildFarm.Core.interfaces;
using WildFarm.Factories.interfaces;
using WildFarm.IO;
using WildFarm.IO.interfaces;

public class StartUp
{
    public static void Main()
    {
        string fileName= @"..\..\..\input.txt";
        IReader reader = new FileReader(fileName);
        IWriter writer = new ConsoleWriter();
        IFoodFactory food = new FoodFactory();
        IAnimalFactory animal = new AnimalFactory();
        IEngine engine = new Engine(reader, writer, animal, food);
        engine.Run();
        //string fileName = @"..\..\..\input.txt";
        //string[] data = File.ReadAllLines(fileName);
        //Console.WriteLine(string.Join(";", data));

        //using (StreamReader sr = File.OpenText(fileName))
        //{
        //    string s = String.Empty;
        //    while ((s = sr.ReadLine()) != null)
        //    {
        //        Console.WriteLine(s);
        //    }
        //}


    }


}
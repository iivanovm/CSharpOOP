namespace WildFarm.Init;
using WildFarm.IO;
using WildFarm.IO.interfaces;
using WildFarm.Core.interfaces;
using WildFarm.Factories.interfaces;
using WildFarm.Core;
using WildFarmV2.IO;

internal class Initiazlize : IInitialize
{
    public void Setup()
    {
        Choice();
    }

    public Initiazlize()
    {
        string fileName;
        string outFile ;
        IReader reader ;
        IWriter writer;
      
    }

    private void Choice()
    {
        Console.WriteLine("Chose your option");
        Console.WriteLine("1. ConsoleReader; ConsoleWriter");
        Console.WriteLine("2. FileReader; ConsoleWriter");
        Console.WriteLine("3. ConsoleReader; FileWriter");
        Console.WriteLine("4. FileReader; FileWriter");
        Console.WriteLine("Plaese enter your choice:");
        int option = int.Parse(Console.ReadLine());
        switch (option)
        {
            case 1:
  
                IReader reader=new ConsoleReader();
                IWriter writer = new ConsoleWriter();
                IFoodFactory food = new FoodFactory();
                IAnimalFactory animal = new AnimalFactory();
                IEngine engine = new Engine(reader, writer, animal, food);
                engine.Run();
                break;
            case 2:
                string fileName = @"..\..\..\input.txt";
                 reader = new FileReader(fileName);
                 writer = new ConsoleWriter();
                 food = new FoodFactory();
                 animal = new AnimalFactory();
                 engine = new Engine(reader, writer, animal, food);
                engine.Run();
                break;
            case 3:
                string outFile = @"..\..\..\Output.txt";
                reader = new ConsoleReader();
                writer = new FileWrite(outFile);
                food = new FoodFactory();
                animal = new AnimalFactory();
                engine = new Engine(reader, writer, animal, food);
                engine.Run();
                break;
            case 4:
                 fileName = @"..\..\..\input.txt";
                 outFile = @"..\..\..\Output.txt";
                 reader = new FileReader(fileName);
                 writer = new FileWrite(outFile);
                 food = new FoodFactory();
                 animal = new AnimalFactory();
                engine = new Engine(reader, writer, animal, food);
                engine.Run();
                break;
            default:
                Console.WriteLine("Incorrect choice");
                break;
        }

    }
}

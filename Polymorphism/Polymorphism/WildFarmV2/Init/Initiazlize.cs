namespace WildFarm.Init;
using WildFarm.IO;
using WildFarm.IO.interfaces;
using WildFarm.Core.interfaces;
using WildFarm.Factories.interfaces;
using WildFarm.Core;
using WildFarmV2.Init.@interface;

internal class Initiazlize : IInitialize
{
    string msgInput = "We need  exact path and filename for  file.\nFor Example c:\\data\\input.txt. If not put direcotry set DefaultSolutionDir \nEnter your path or press enter for default...:";
    public void Setup()
    {
        Choice();
    }

    public Initiazlize()
    {
        string fileName;
        string outFile;
        string outFileJ;
        IReader reader;
        IWriter writer;
    }

    private void Choice()
    {
        List<string> MenuItem = new List<string>()
        { "1. ConsoleReader; ConsoleWriter",
            "2. FileReader; ConsoleWriter",
            "3. ConsoleReader; FileWriter",
            "4. FileReader; FileWriter",
            "5. FileReader; FileWriter export to Jsons",
            "6. Exit"
        };
        Console.CursorVisible = false;
        while (true)
        {
            switch (MenuInit.Menu(MenuItem))
            {
                case "1. ConsoleReader; ConsoleWriter":
                    IReader reader = new ConsoleReader();
                    IWriter writer = new ConsoleWriter();
                    IFoodFactory food = new FoodFactory();
                    IAnimalFactory animal = new AnimalFactory();
                    IEngine engine = new Engine(reader, writer, animal, food);
                    engine.Run();
                    break;
                case "2. FileReader; ConsoleWriter":
                    string fileName;
                    Console.WriteLine("Input " + msgInput);
                    fileName = Console.ReadLine();
                    if (fileName == string.Empty)
                    {
                        fileName = @"..\..\..\DataStore\input.txt";
                    }
                    else
                    {
                        fileName = fileName.Replace(@"\", @"\\");
                    }
                    reader = new FileReader(fileName);
                    writer = new ConsoleWriter();
                    food = new FoodFactory();
                    animal = new AnimalFactory();
                    engine = new Engine(reader, writer, animal, food);
                    engine.Run();
                    break;
                case "3. ConsoleReader; FileWriter":
                    string outFile;
                    Console.WriteLine("OutFile " + msgInput);
                    outFile = Console.ReadLine();
                    if (outFile == string.Empty)
                    {
                        outFile = @"..\..\..\DataStore\Output.txt";
                    }
                    else
                    {
                        outFile = outFile.Replace(@"\", @"\\");
                    }
                    reader = new ConsoleReader();
                    writer = new FileWrite(outFile);
                    food = new FoodFactory();
                    animal = new AnimalFactory();
                    engine = new Engine(reader, writer, animal, food);
                    engine.Run();
                    break;
                case "4. FileReader; FileWriter":
                    Console.WriteLine("Input " + msgInput);
                    fileName = Console.ReadLine();
                    if (fileName == string.Empty)
                    {
                        fileName = @"..\..\..\DataStore\input.txt";
                    }
                    else
                    {
                        fileName = fileName.Replace(@"\", @"\\");
                    }
                    Console.WriteLine("OutFile " + msgInput);
                    outFile = Console.ReadLine();
                    if (outFile == string.Empty)
                    {
                        outFile = @"..\..\..\DataStore\Output.txt";
                    }
                    else
                    {
                        outFile = outFile.Replace(@"\", @"\\");
                    }
                    fileName = @"..\..\..\DataStore\input.txt";
                    outFile = @"..\..\..\DataStore\Output.txt";
                    reader = new FileReader(fileName);
                    writer = new FileWrite(outFile);
                    food = new FoodFactory();
                    animal = new AnimalFactory();
                    engine = new Engine(reader, writer, animal, food);
                    engine.Run();
                    break;
                case "5. FileReader; FileWriter export to Jsons":
                    Console.WriteLine("Input " + msgInput);
                    fileName = Console.ReadLine();
                    if (fileName == string.Empty)
                    {
                        fileName = @"..\..\..\DataStore\input.txt";
                    }
                    else
                    {
                        fileName = fileName.Replace(@"\", @"\\");
                    }
                    Console.WriteLine("OutFile " + msgInput);
                    string outFileJ = Console.ReadLine();
                    if (outFileJ == string.Empty)
                    {
                        outFileJ = @"..\..\..\DataStore\OutputJ.txt";
                    }
                    else
                    {
                        outFileJ = outFileJ.Replace(@"\", @"\\");
                    }
                    fileName = @"..\..\..\DataStore\input.txt";
                    outFileJ = @"..\..\..\DataStore\OutputJ.txt";
                    reader = new FileReader(fileName);
                    writer = new FileWrite(outFileJ);
                    food = new FoodFactory();
                    animal = new AnimalFactory();
                    engine = new Engine(reader, writer, animal, food, 5);
                    engine.Run();
                    break;
                case "6. Exit":
                    Environment.Exit(0);
                    break;
            }
        }

    }
}

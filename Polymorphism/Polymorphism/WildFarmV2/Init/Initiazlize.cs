namespace WildFarmV2.Init;
using System;
using WildFarmV2.IO;
using WildFarmV2.IO.interfaces;
using WildFarmV2.Core.interfaces;
using WildFarmV2.Factories.interfaces;
using WildFarmV2.Core;
using WildFarmV2.Init.@interface;
using WildFarmV2;
using WildFarm.IO;

internal class Initiazlize : IInitialize
{
    private string msgInput = $"We need  exact path and filename for  file.\nFor Example c:\\data\\input.txt. If not put direcotry set DefaultSolutionDir \nEnter your path or press enter for default...:";
    private string fileName;
    private string outFile;
    private string outFileJ;


    private IFoodFactory food;
    private IAnimalFactory animal;
    private IEngine engine;
    private IReader reader;
    private IWriter writer;



    public Initiazlize()
    {
        fileName = @"..\..\..\DataStore\input.txt";
        outFile = @"..\..\..\DataStore\Output.txt";
        outFileJ = @"..\..\..\DataStore\OutputJ.txt";
        food = new FoodFactory();
        animal = new AnimalFactory();
    }



    public void Setup()
    {
        Choice();
    }
    private void Choice()
    {
        List<string> MenuItem = new List<string>()
        {  "1. ConsoleReader; ConsoleWriter",
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
                    reader = new ConsoleReader();
                    writer = new ConsoleWriter();
                    engine = new Engine(reader, writer, animal, food);
                    engine.Run();
                    break;


                case "2. FileReader; ConsoleWriter":
                    reader = new FileReader(fileName);
                    writer = new ConsoleWriter();
                    engine = new Engine(reader, writer, animal, food);
                    engine.Run();
                    break;


                case "3. ConsoleReader; FileWriter":
                    Console.WriteLine("OutFile " + msgInput);
                    Console.ResetColor();
                    string outFileInp = Console.ReadLine();
                    if (outFileInp != string.Empty)
                    {
                        outFile = outFileInp.Replace(@"\", @"\\");
                    }
                    reader = new ConsoleReader();
                    writer = new FileWrite(outFile);
                    engine = new Engine(reader, writer, animal, food);
                    engine.Run();
                    break;


                case "4. FileReader; FileWriter":
                    Console.WriteLine("Input " + msgInput);
                    Console.ResetColor();
                    string fileNameInp = Console.ReadLine();
                    if (fileNameInp != string.Empty)
                    {
                        fileName = fileNameInp.Replace(@"\", @"\\");
                    }
                    Console.WriteLine("OutFile " + msgInput);
                    outFileInp = Console.ReadLine();
                    if (outFileInp != string.Empty)
                    {
                        outFile = outFileInp.Replace(@"\", @"\\");
                    }
                    reader = new FileReader(fileName);
                    writer = new FileWrite(outFile);
                    engine = new Engine(reader, writer, animal, food);
                    engine.Run();
                    break;


                case "5. FileReader; FileWriter export to Jsons":
                    Console.WriteLine("Input " + msgInput);
                    Console.ResetColor();
                    fileNameInp = Console.ReadLine();
                    if (fileNameInp != string.Empty)
                    {
                        fileName = fileNameInp.Replace(@"\", @"\\");
                    }
                    Console.WriteLine("OutFile " + msgInput);
                    Console.ResetColor();
                    outFileInp = Console.ReadLine();
                    if (outFileInp != string.Empty)
                    {
                        outFileJ = outFileInp.Replace(@"\", @"\\");
                    }
                    reader = new FileReader(fileName);
                    writer = new FileWrite(outFileJ);
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

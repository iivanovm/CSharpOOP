namespace BorderControl;
using BirthdayCelebrations;
using BirthdayCelebrations.Models.Interfaces;
using BorderControl.Core.Interface;
using BorderControl.IO.interfaces;
using BorderControl.Models;
using BorderControl.Models.Interfaces;

public class Engine : IEngine
{
    protected List<IBerthdable> Persons = new List<IBerthdable>();
    private readonly IReader reader;
    private readonly IWriter writer;
    private ICitizen citizen;
    private IRobot robot;
    private IPet pet;
    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }


    public void Run()
    {
        List<string> ids = new List<string>();
        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            switch (tokens.Count())
            {
                case 3:
                    if (tokens[0] == "Pet")
                    {
                        pet = new Pets(tokens[1], tokens[2]);
                        Persons.Add(pet);
                    }
                    break;
                case > 3:
                    citizen = new Citizens(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
                    Persons.Add(citizen);
                    break;
            }
        }
        string year = Console.ReadLine();
        foreach (var item in Persons)
        {
            if (item.Birthday.EndsWith(year))
            {
                ids.Add(item.Birthday);
            }
        }
        ids.ForEach(id => Console.WriteLine(id));

    }
}

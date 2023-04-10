namespace BorderControl;
using BorderControl.Core.Interface;
using BorderControl.IO.interfaces;
using BorderControl.Models;
using BorderControl.Models.Interfaces;

public class Engine : IEngine
{
    protected List<IPerson> Persons = new List<IPerson>();
    private readonly IReader reader;
    private readonly IWriter writer;
    private ICitizen citizen;
    private IRobot robot;
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
                case 2:
                    robot = new Robots(tokens[0], tokens[1]);
                    Persons.Add(robot);
                    break;
                case 3:
                    citizen = new Citizens(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    Persons.Add(citizen);
                    break;
            }
        }
        string key = Console.ReadLine();
        foreach (var item in Persons)
        {
            if (item.Id.EndsWith(key))
            {
                ids.Add(item.Id.ToString());
            }
        }


        ids.ForEach(id => Console.WriteLine(id));
    }
}

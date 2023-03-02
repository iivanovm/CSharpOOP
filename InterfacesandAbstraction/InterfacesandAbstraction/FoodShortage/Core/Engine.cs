namespace BorderControl;
using BirthdayCelebrations;
using BirthdayCelebrations.Models.Interfaces;
using BorderControl.Core.Interface;
using BorderControl.IO.interfaces;
using BorderControl.Models;
using BorderControl.Models.Interfaces;
using FoodShortage.Models;

public class Engine : IEngine
{
    protected List<IBerthdable> Persons = new List<IBerthdable>();
    private readonly IReader reader;
    private readonly IWriter writer;
    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }
    public Engine()
    {

    }


    public void Run()
    {
        int personCount = int.Parse(reader.ReadLine());
        List<Rebel> rebels = new List<Rebel>();
        List<Citizens> citizens = new List<Citizens>();
        for (int i = 0; i < personCount; i++)
        {
            string[] tokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Count() != 3)
            {

                citizens.Add(new Citizens(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]));
            }
            else
            {
                rebels.Add(new(tokens[0], int.Parse(tokens[1]), tokens[2]));
            }
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            if (citizens.Any(x => x.Name == command))
            {
                citizens.Where(c => c.Name == command).FirstOrDefault().BuyFood();
            }
            else if (rebels.Any(x => x.Name == command))
            {
                rebels.Where(r => r.Name == command).FirstOrDefault().BuyFood();
            }
        }
        writer.WriteLine($"{citizens.Sum(c => c.Food) + rebels.Sum(r => r.Food)}");


    }
}

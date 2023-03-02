namespace ExplicitInterfaces.Core;
using Core.interfaces;
using ExplicitInterfaces.IO.interfaces;
using ExplicitInterfaces.Models;
using ExplicitInterfaces.Models.Interfaces;

public class Engine : IEngine
{
    public void run(IReader reader, IWriter writer)
    {

        Citizen citizen;
        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0];
            string country = tokens[1];
            int age = int.Parse(tokens[2]);
            citizen = new Citizen(name, country, age);
            IPerson person = citizen;
            IResident resident = citizen;
            person.GetName();
            resident.GetName();

        }
    }
}

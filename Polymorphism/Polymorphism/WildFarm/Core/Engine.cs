using WildFarm.Core.interfaces;
using WildFarm.IO;
using WildFarm.IO.interfaces;
using WildFarm.Models;
using WildFarm.Models.AbstractCl;
using WildFarm.Models.Struct;

namespace WildFarm.Core;

public class Engine : AnimalBuildr, IEngine
{

    List<Animal> animals;  
    public Engine()
    {
       animals = new List<Animal>();
        
    }
    public void Start(IReader reader, IWriter writer)
    {
        string command;
        while ((command = reader.ReadLine()) != "End")
        {

            string[] animal = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] eat = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            animals.Add(CreateAnimal(animal,eat));
        }

       animals.ForEach(x=>Console.WriteLine(x));
    }



}

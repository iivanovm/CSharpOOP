namespace WildFarmV2.Core;
using WildFarmV2.Core.interfaces;
using WildFarmV2.Factories.interfaces;
using WildFarmV2.IO.interfaces;
using WildFarmV2.Models.interfaces;


public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;
    private IFoodFactory foodFactory;
    private IAnimalFactory animalFactory;
    private readonly ICollection<IAnimal> animals;
    private int type;
    public Engine(
          IReader reader,
          IWriter writer,
          IAnimalFactory animalFactory,
          IFoodFactory foodFactory,
          int type=1 )
    {
        this.reader = reader;
        this.writer = writer;
       
        this.animalFactory = animalFactory;
        this.foodFactory = foodFactory;

        animals = new List<IAnimal>();

        this.type = type;
    }

    public void Run()
    {
        string command;
        while ((command = reader.ReadLine()) != "End")
        {
          
            IAnimal animal = null;
            try
            {
                animal = CreateAnimal(command);

                IFood food = CreateFood();

                writer.WriteLine(animal.ProduceSound());

                animal.Eat(food);

            }
            catch (ArgumentException ex)
            {
                writer.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }

            animals.Add(animal);
        }
        if (type == 5)
        {
            writer.WriteToJson(animals);
        }
        else
        {

            foreach (IAnimal animal in animals)
            {
                writer.WriteLine(animal.ToString());
            }
        }
    }

    private IAnimal CreateAnimal(string command)
    {
        string[] animalArgs = command
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        IAnimal animal = animalFactory.CreateAnimal(animalArgs);

        return animal;
    }

    private IFood CreateFood()
    {

        string[] foodTokens =reader.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string foodType = foodTokens[0];
        int foodQuantity = int.Parse(foodTokens[1]);

        IFood food = foodFactory.CreateFood(foodType, foodQuantity);

        return food;
    }

}


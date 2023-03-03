namespace WildFarm.Core;
using WildFarm.Enums;

using WildFarm.Enums;
using WildFarm.Models;
using WildFarm.Models.AbstractCl;
using WildFarm.Models.Struct;

public class Checks
{
    protected bool isvalidFood(string[] input)
    {
        string foodName = input[0];
        bool isValid = Enum.TryParse(foodName, out HensEat hensEat);
        if (isValid)
        {
            return isValid;
        }
        return isValid;
    }

    protected int CatFood(string[] input)
    {
        string foodName = input[0];
        int foodQuantity = int.Parse(input[1]);
        bool isValid = Enum.TryParse(foodName, out CatEat hensEat);
        if (isValid)
        {
            return foodQuantity;
        }
        return 0;
    }

    protected int DogFood(string[] input)
    {
        string foodName = input[0];
        int foodQuantity = int.Parse(input[1]);
        bool isValid = Enum.TryParse(foodName, out DogEat hensEat);
        if (isValid)
        {
            return foodQuantity;
        }
        return 0;
    }

    protected int HensFood(string[] input)
    {
        string foodName = input[0];
        int foodQuantity = int.Parse(input[1]);
        bool isValid = Enum.TryParse(foodName, out HensEat hensEat);
        if (isValid)
        {
            return foodQuantity;
        }
        return 0;
    }

    protected int MiceFood(string[] input)
    {
        string foodName = input[0];
        int foodQuantity = int.Parse(input[1]);
        bool isValid = Enum.TryParse(foodName, out MouseEat hensEat);
        if (isValid)
        {
            return foodQuantity;
        }
        return 0;
    }

    protected void PrintAnimal(Animal animal, string[] eats,string[] animals)
    {
        string animalType = animals[0];
            Console.WriteLine(animal.ProduceSound());

        switch (animal.GetType().Name)
        {
            case "Owl":
                if (DogFood(eats) == 0)
                {
                    Console.WriteLine($"{animalType} does not eat {eats[0]}!");
                }
                break;
            case "Hen":
                if (HensFood(eats) == 0)
                {
                    Console.WriteLine($"{animalType} does not eat {eats[0]}!");
                }
                break;
            case "Mouse":
                if (MiceFood(eats) == 0)
                {
                    Console.WriteLine($"{animalType} does not eat {eats[0]}!");
                }
                break;
            case "Dog":
                if (DogFood(eats) == 0)
                {
                    Console.WriteLine($"{animalType} does not eat {eats[0]}!");
                }
                break;
            case "Cat":
                if (CatFood(eats) == 0)
                {
                    Console.WriteLine($"{animalType} does not eat {eats[0]}!");
                }
                break;
            case "Tiger":
                if (DogFood(eats) == 0)
                {
                    Console.WriteLine($"{animalType} does not eat {eats[0]}!");
                }
                break;
        }
    }

    public Birds Birds(string[] tokens)
    {
        Birds currentBirds = new Birds();
        currentBirds.Name = tokens[1];
        currentBirds.Weight = double.Parse(tokens[2]);
        currentBirds.WingSize = double.Parse(tokens[3]);
        return currentBirds;
    }

    public Felines Felines(string[] tokens)
    {
        Felines currentFelines = new Felines();
        currentFelines.Name = tokens[1];
        currentFelines.Weight = double.Parse(tokens[2]);
        currentFelines.LivingRegion = tokens[3];
        currentFelines.Breed = tokens[4];
        return currentFelines;
    }

    public Dogs Dogy(string[] tokens)
    {
        Dogs currentDogs = new Dogs();
        currentDogs.Name = tokens[1];
        currentDogs.Weight = double.Parse(tokens[2]);
        currentDogs.Living = tokens[3];
        return currentDogs;
    }
}

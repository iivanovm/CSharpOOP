using WildFarm.Enums;
using WildFarm.Models;
using WildFarm.Models.AbstractCl;
using WildFarm.Models.Struct;

namespace WildFarm.Core;

public class AnimalBuildr : Checks
{
    Animal animal = null;
    public Animal CreateAnimal(string[] animalInput, string[] eats)
    {
        string animalType = animalInput[0];
        switch (animalType)
        {
            case "Owl":
                animal = new Owl(Birds(animalInput).Name, Birds(animalInput).Weight, DogFood(eats), Birds(animalInput).WingSize);
                PrintAnimal(animal, eats,animalInput);
                break;
            case "Hen":
                PrintAnimal(animal, eats,animalInput);
                break;
            case "Mouse":
                animal = new Mouse(Dogy(animalInput).Name, Dogy(animalInput).Weight, MiceFood(eats), Dogy(animalInput).Living);
                PrintAnimal(animal, eats, animalInput);
                break;
            case "Dog":
                animal = new Dog(Dogy(animalInput).Name, Dogy(animalInput).Weight, DogFood(eats), Dogy(animalInput).Living);
                PrintAnimal(animal, eats, animalInput);
                break;
            case "Cat":
                animal = new Cat(Felines(animalInput).Name, Felines(animalInput).Weight, CatFood(eats), Felines(animalInput).LivingRegion, Felines(animalInput).Breed);
                PrintAnimal(animal, eats, animalInput);
                break;
            case "Tiger":
                animal = new Tiger(Felines(animalInput).Name, Felines(animalInput).Weight, DogFood(eats), Felines(animalInput).LivingRegion, Felines(animalInput).Breed);
                PrintAnimal(animal, eats, animalInput);
                break;

        }
        return animal;
    }


}

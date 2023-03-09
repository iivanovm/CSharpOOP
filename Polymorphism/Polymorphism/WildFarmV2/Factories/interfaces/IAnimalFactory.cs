using WildFarm.Models.interfaces;

namespace WildFarm.Factories.interfaces;

public interface IAnimalFactory
{
    IAnimal CreateAnimal(string[] animalTokens);
}
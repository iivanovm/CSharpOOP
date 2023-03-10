using WildFarmV2.Models.interfaces;

namespace WildFarmV2.Factories.interfaces;

public interface IAnimalFactory
{
    IAnimal CreateAnimal(string[] animalTokens);
}
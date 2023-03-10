namespace WildFarmV2.Models.interfaces;

public interface IAnimal
{
    
    string AnimalName { get; }
    double AnimalWeight { get; }
    int AnimalFoodEaten { get; }

    string ProduceSound();

    void Eat(IFood food);
}

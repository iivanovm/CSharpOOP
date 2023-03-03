namespace WildFarm.Models.AbstractCl;
using WildFarm.Models.interfaces;


public abstract class Animal : IAnimal
{
    protected Animal(string name, double weight, int foodEaten)
    {
        Name = name;
        Weight = weight;
        FoodEaten = foodEaten;
    }

    protected string Name { get; private set; }
    protected double Weight { get; private set; }
    protected int FoodEaten { get; private set; }

    public abstract string ProduceSound();

}

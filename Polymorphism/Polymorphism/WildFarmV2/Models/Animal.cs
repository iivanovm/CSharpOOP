using WildFarmV2.Models.interfaces;

namespace WildFarmV2.Models;

public abstract class Animal : IAnimal
{
    protected Animal(string animalName, double animalWeight)
    {
        AnimalName = animalName;
        AnimalWeight = animalWeight;
    }

    protected abstract double WeightMultiplier { get; }
    public string AnimalName { get; protected set; }

    public double AnimalWeight { get; protected set; }

    public int AnimalFoodEaten { get; protected set; }

    public abstract IReadOnlyCollection<Type> PreferredFoods { get; }

    public abstract string ProduceSound();

    public void Eat(IFood food)
    {
        if (!PreferredFoods.Any(pf => food.GetType().Name == pf.Name))
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        AnimalWeight += food.Quantity * WeightMultiplier;

        AnimalFoodEaten += food.Quantity;
    }

    public override string ToString()
        => $"{GetType().Name} [{AnimalName}, ";
}


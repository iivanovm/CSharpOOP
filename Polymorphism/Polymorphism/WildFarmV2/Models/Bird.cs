using WildFarm.Models.interfaces;

namespace WildFarm.Models;

public abstract class Bird : Animal, IBird
{
    protected Bird(string animalName, double animalWeight,double wingSize) :
        base(animalName, animalWeight)
    {
        WingSize = wingSize;
    }

    public double WingSize { get; private set; }

    public override string ToString()=>base.ToString()+$"{WingSize}, {AnimalWeight}, {AnimalFoodEaten}]";
}
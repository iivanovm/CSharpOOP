using WildFarmV2.Models.interfaces;
    
namespace WildFarmV2.Models;

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
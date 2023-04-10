using WildFarm.Models.AbstractCl;

namespace WildFarm.Models;

public class Dog : Mammal
{
    private const double animaWplusDog = 0.40;
    public Dog(string name, double weight, int foodEaten, string livingRegion) 
        : base(name, weight, foodEaten, livingRegion, animaWplusDog)
    {

    }

    public override string ProduceSound() => "Woof!";

    
}
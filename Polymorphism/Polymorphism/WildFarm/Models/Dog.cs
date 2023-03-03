using WildFarm.Models.AbstractCl;

namespace WildFarm.Models;

public class Dog : Mammal
{
    public Dog(string name, double weight, int foodEaten, string livingRegion) 
        : base(name, weight, foodEaten, livingRegion)
    {

    }

    public override string ProduceSound() => "Woof!";

    
}
using WildFarm.Models.AbstractCl;

namespace WildFarm.Models;

public class Dog : Mammal
{
    public Dog(string name, double weight, int foodEaten) 
        : base(name, weight, foodEaten)
    {
    }

    public override string ProduceSound() => "Woof!";
}
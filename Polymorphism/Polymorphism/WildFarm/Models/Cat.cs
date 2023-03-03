using WildFarm.Models.AbstractCl;

namespace WildFarm.Models;

public class Cat : Feline
{
    public Cat(string name, double weight, int foodEaten, string breed)
        : base(name, weight, foodEaten, breed)
    {

    }

    public override string ProduceSound() => "Meow";
}

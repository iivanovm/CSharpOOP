using WildFarm.Models.AbstractCl;

namespace WildFarm.Models;

public class Mouse : Mammal
{
    public Mouse(string name, double weight, int foodEaten) 
        : base(name, weight, foodEaten)
    {
    }

    public override string ProduceSound() => "Squeak";
}

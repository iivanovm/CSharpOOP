using WildFarm.Models.AbstractCl;

namespace WildFarm.Models;

public class Mouse : Mammal
{
    private const double MouseWplus = 0.10;
    public Mouse(string name, double weight, int foodEaten, string livingRegion) 
        : base(name, weight, foodEaten, livingRegion,MouseWplus)
    {
    }

    public override string ProduceSound() => "Squeak";
}

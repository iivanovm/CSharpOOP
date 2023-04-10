using WildFarm.Models.AbstractCl;

namespace WildFarm.Models;

public class Owl : Bird
{
    private const double OwlWPlus= 0.25;
    public Owl(string name, double weight, int foodEaten, double wingSize)
        : base(name, weight, foodEaten, wingSize,OwlWPlus)
    {

    }

    public override string ProduceSound() => "Hoot Hoot";
}
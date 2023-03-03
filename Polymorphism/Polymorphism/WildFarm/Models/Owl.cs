using WildFarm.Models.AbstractCl;

namespace WildFarm.Models;

public class Owl : Bird
{
    public Owl(string name, double weight, int foodEaten, double wingSize)
        : base(name, weight, foodEaten, wingSize)
    {

    }

    public override string ProduceSound() => "Hoot Hoot";
}
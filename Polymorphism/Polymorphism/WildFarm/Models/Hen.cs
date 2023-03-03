using WildFarm.Models.AbstractCl;

namespace WildFarm.Models;
public class Hen : Bird
{
    private const double HenWplus = 0.35;
    public Hen(string name, double weight, int foodEaten, double wingSize)
        : base(name, weight, foodEaten, wingSize,HenWplus)
    {
    }

    public override string ProduceSound() => "Cluck";
}
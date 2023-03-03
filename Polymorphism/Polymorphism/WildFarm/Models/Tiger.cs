using WildFarm.Models.AbstractCl;

namespace WildFarm.Models;

public class Tiger : Feline
{
    private const double TigerWplus = 1.00;
    public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed) 
        : base(name, weight, foodEaten, livingRegion, breed,TigerWplus)
    {
    }

    public override string ProduceSound() => "ROAR!!!";
}
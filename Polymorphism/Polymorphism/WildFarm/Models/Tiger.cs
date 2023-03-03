using WildFarm.Models.AbstractCl;

namespace WildFarm.Models;

public class Tiger : Feline
{
    public Tiger(string name, double weight, int foodEaten, string breed) 
        : base(name, weight, foodEaten, breed)
    {

    }

    public override string ProduceSound() => "ROAR!!!";
}
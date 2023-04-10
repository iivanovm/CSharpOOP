using WildFarmV2.Models.Foods;

namespace WildFarmV2.Models.Animals;

public class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    {
    }

    public override IReadOnlyCollection<Type> PreferredFoods
     => new HashSet<Type>() { typeof(Meat) };

    protected override double WeightMultiplier => 1.00;

    public override string ProduceSound() => "ROAR!!!";
}

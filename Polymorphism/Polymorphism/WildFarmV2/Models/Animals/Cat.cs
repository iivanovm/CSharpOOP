using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals;

public class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    {

    }

    public override IReadOnlyCollection<Type> PreferredFoods
 => new HashSet<Type>() { typeof(Meat), typeof(Vegetable) };

    protected override double WeightMultiplier => 0.30;

    public override string ProduceSound() => "Meow";
}

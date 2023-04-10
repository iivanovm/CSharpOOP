using WildFarmV2.Models.Foods;

namespace WildFarmV2.Models.Animals;

public class Dog : Mammal
{
    public Dog(string animalName, double animalWeight, string livingRegion) 
        : base(animalName, animalWeight, livingRegion)
    {
    }

    public override IReadOnlyCollection<Type> PreferredFoods
 => new HashSet<Type>() { typeof(Meat) };

    protected override double WeightMultiplier => 0.40;

    public override string ProduceSound() => "Woof!";

    public override string ToString()
        => base.ToString() + $"{AnimalWeight}, {LivinigRegion}, {AnimalFoodEaten}]";

}

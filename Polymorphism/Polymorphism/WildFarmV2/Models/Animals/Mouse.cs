using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals;

public class Mouse : Mammal
{
    public Mouse(string animalName, double animalWeight, string livingRegion) 
        : base(animalName, animalWeight, livingRegion)
    {

    }

    public override IReadOnlyCollection<Type> PreferredFoods
=> new HashSet<Type>() {typeof(Vegetable), typeof(Fruit)};

    protected override double WeightMultiplier => 0.10;

    public override string ProduceSound() => "Squeak";
    public override string ToString()
        => base.ToString() + $"{AnimalWeight}, {LivinigRegion}, {AnimalFoodEaten}]";
}
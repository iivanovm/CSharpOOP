using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals;


public class Owl : Bird
{
    public Owl(string animalName, double animalWeight, double wingSize) 
        : base(animalName, animalWeight, wingSize)
    {

    }

    public override IReadOnlyCollection<Type> PreferredFoods
     => new HashSet<Type>() { typeof(Meat) };

    protected override double WeightMultiplier => 0.25;

    public override string ProduceSound() => "Hoot Hoot";
}

using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals;

public class Hen : Bird
{
    public Hen(string animalName, double animalWeight, double wingSize)
        : base(animalName, animalWeight, wingSize)
    {

    }


    public override IReadOnlyCollection<Type> PreferredFoods
 => new HashSet<Type>() { typeof(Meat), typeof(Vegetable), typeof(Fruit), typeof(Seeds) };
    protected override double WeightMultiplier => 0.35;

    public override string ProduceSound() => "Cluck";
}

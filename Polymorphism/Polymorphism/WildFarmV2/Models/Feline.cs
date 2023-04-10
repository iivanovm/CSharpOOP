namespace WildFarmV2.Models;
using WildFarmV2.Models.interfaces;



public abstract class Feline : Mammal, IFeline
{
    protected Feline(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion)
    {
        Breed = breed;
    }

    public string Breed { get; private set; }

    public override string ToString()
        => base.ToString() + $"{Breed}, {AnimalWeight}, {LivinigRegion}, {AnimalFoodEaten}]";
}
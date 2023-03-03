namespace WildFarm.Models.AbstractCl;

public abstract class Feline : Mammal
{
    protected Feline(string name, double weight, int foodEaten, string livingRegion, string breed, double animalWplus) 
        : base(name, weight, foodEaten, livingRegion, animalWplus)
    {
        Breed = breed;
    }

    protected string Breed { get; private set; }



    public override string ToString()
    {
        return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}

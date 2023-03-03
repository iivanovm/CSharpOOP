namespace WildFarm.Models.AbstractCl;

public abstract class Mammal : Animal
{
    protected Mammal(string name, double weight, int foodEaten, string livingRegion,double animalWplus) 
        : base(name, weight, foodEaten, animalWplus)
    {
        LivingRegion = livingRegion;
    }

    public string LivingRegion { get; set; }

    public override string ToString()
    {
        return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}


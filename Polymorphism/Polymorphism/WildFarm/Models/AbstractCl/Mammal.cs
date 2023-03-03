namespace WildFarm.Models.AbstractCl;

public abstract class Mammal : Animal
{
    protected Mammal(string name, double weight, int foodEaten)
        : base(name, weight, foodEaten)
    {
    }

    public string LivingRegion { get; set; }
}


namespace WildFarm.Models.AbstractCl;

public abstract class Feline : Mammal
{
    protected string Breed { get; private set; }

    protected Feline(string name, double weight, int foodEaten, string breed)
        : base(name, weight, foodEaten)
    {
        Breed = breed;
    }
}

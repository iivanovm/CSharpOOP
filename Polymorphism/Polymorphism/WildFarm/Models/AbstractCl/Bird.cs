namespace WildFarm.Models.AbstractCl;

public abstract class Bird : Animal
{
    protected double WingSize { get; set; }

    protected Bird(string name, double weight, int foodEaten, double wingSize) :
        base(name, weight, foodEaten)
    {
        WingSize = wingSize;
    }


    public override string ToString()
    {
        return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
    }
}

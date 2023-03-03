namespace WildFarm.Models.AbstractCl;
using WildFarm.Models.interfaces;


public abstract class Animal : IAnimal
{
    private int foodEaten;
    private double animalWplus;
    protected Animal(string name, double weight, int foodEaten,double animalWplus)
    {
        Name = name;
        Weight = weight;
        FoodEaten = foodEaten;
        AnimalWplus = animalWplus;
    }



    protected string Name { get; private set; }
    protected double Weight { get; private set; }
    protected int FoodEaten {
        get
        {
            return foodEaten;
        }
         set
        {
            foodEaten = value;
        }
    }

    public double AnimalWplus {
        get
        {
            return animalWplus;
        }

        set
        {
            animalWplus= value*FoodEaten;
            Weight += animalWplus;
        }
    }

    public abstract string ProduceSound();

}

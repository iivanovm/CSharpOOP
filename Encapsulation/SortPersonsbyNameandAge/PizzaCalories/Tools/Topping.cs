namespace PizzaCalories.Tools;

public class Topping
{
    private string toppingType;
    private double weight;

    public Topping(string toppingType, double weight)
    {
        ToppingType = toppingType;
        Weight = weight;
    }

    public string ToppingType
    {
        get
        {
            return toppingType;
        }
        private set
        {
            if (value != "meat" && value != "veggies" && value != "cheese" && value != "sauce")
            {
                var valueName = value[0].ToString().ToUpper() + value.Substring(1);
                throw new Exception($"Cannot place {valueName} on top of your pizza.");
            }

            toppingType = value;
        }
    }

    public double Weight
    {
        get
        {
            return weight;
        }
        private set
        {
            if (value < 1 || value > 50)
            {
                var valueName = toppingType[0].ToString().ToUpper() + toppingType.Substring(1);
                throw new Exception($"{valueName} weight should be in the range [1..50].");
            }

            weight = value;
        }
    }

    public double ToppingCalories()
    {
        return 2 * Weight * ToppingTypeModifier();
    }

    private double ToppingTypeModifier()
    {
        if (ToppingType == "meat")
        {
            return 1.2;
        }
        else if (ToppingType == "veggies")
        {
            return 0.8;
        }
        else if (ToppingType == "cheese")
        {
            return 1.1;
        }
        else
        {
            return 0.9;
        }
    }
}


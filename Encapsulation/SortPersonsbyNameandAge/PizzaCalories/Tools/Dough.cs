namespace PizzaCalories.Tools;

public class Dough
{
    private string flourType;
    private string bakingTechnique;
    private double weight;

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }

    public string FlourType
    {
        get
        {
            return flourType;
        }
        private set
        {
            if (value != "white" && value != "wholegrain")
            {
                throw new Exception("Invalid type of dough.");
            }

            flourType = value;

        }
    }

    public string BakingTechnique
    {
        get
        {
            return bakingTechnique;
        }
        private set
        {
            if (value != "crispy" && value != "chewy" && value != "homemade")
            {
                throw new Exception("Invalid type of dough.");
            }

            bakingTechnique = value;
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
            if (value < 1 || value > 200)
            {
                throw new Exception("Dough weight should be in the range [1..200].");
            }

            weight = value;
        }
    }

    public double DoughCalories()
    {
        return 2 * Weight * FlourModifier() * BakingTechniqueModifier();
    }

    private double BakingTechniqueModifier()
    {
        if (FlourType == "white")
        {
            return 1.5;
        };

        return 1.0;
    }

    private double FlourModifier()
    {
        if (BakingTechnique == "crispy")
        {
            return 0.9;
        }
        else if (BakingTechnique == "chewy")
        {
            return 1.1;
        }
        else
        {
            return 1.0;
        }
    }
}

namespace ShoppingSpree;

public class Person
{
    private string name;
    private double money;

    public Person(string name, double money)
    {
        Name = name;
        Money = money;
        Bag = new List<Product>();
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            if (value.Length < 0)
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }

    public double Money
    {
        get
        {
            return money;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            money = value;
        }

    }

    private List<Product> Bag { get; set; }


    public void Bought(Product product)
    {
        if(product.Cost<=money)
        {
            Bag.Add(product);
            money-=product.Cost;
            Console.WriteLine($"{Name} bought {product.Name}");
        }
        else
        {
            Console.WriteLine($"{Name} can't afford {product.Name}");
        }
    }

    public override string ToString()
    {
        if (Bag.Count == 0)
        {
            return $"{Name} - Nothing bought";
        }
        return $"{Name} - {string.Join(", ", Bag)}";
    }
}

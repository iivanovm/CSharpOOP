using System.Text;
using System;
namespace Animals;

public abstract class Animal
{
    private string name;
    private int age;
    private string gender;
    protected Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(Name), "Name cannot be null or white space");
            }
            this.name = value;
        }
    }
    public int Age
    {
        get
        {
            return age;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException(nameof(Age), "Age must be positive");
            }
            age = value;
        }
    }
    public string Gender
    {
        get
        {
            return gender;
        }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(gender),"Gender cannot be null or whitespace!");
            }
            gender = value;
        }
    }



    public abstract string ProduceSound();


    public override string ToString()
    {
        StringBuilder animal = new StringBuilder();

        animal
            .AppendLine($"{this.GetType().Name}")
            .AppendLine($"{Name} {Age} {Gender}")
            .AppendLine($"{ProduceSound()}");

        return animal.ToString().Trim();
    }

}

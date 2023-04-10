namespace Animals;

public class Kitten : Cat
{
    private const string  catGender= "Female";
    public Kitten(string name, int age) 
        : base(name, age, catGender)
    {

    }

    public override string ProduceSound()
    {
        return "Meow";
    }
}

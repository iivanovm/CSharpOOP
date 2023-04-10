namespace Animals;

public class Tomcat : Cat
{
    private const string tomCatGender= "Male";
    public Tomcat(string name, int age)
        : base(name, age, tomCatGender)
    {

    }

    public override string ProduceSound()
    {
        return "MEOW";
    }
}

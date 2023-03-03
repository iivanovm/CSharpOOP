using System.Security.Cryptography.X509Certificates;

public abstract class BaseHero
{

    protected BaseHero(string name, int power)
    {
        Name = name;
        Power = power;
    }

    protected  string Name { get;  set; }
    public  int Power { get; set; }
    public abstract string CastAbility();

}


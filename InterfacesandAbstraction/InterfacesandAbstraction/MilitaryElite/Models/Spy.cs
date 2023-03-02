namespace MilitaryElite;
using Models.Interfaces;
using Models;


public class Spy : Soldier, ISpy
{
    public Spy()
    {
        
    }

    public Spy(int id, string firstName, string lastName,int spyNumber) 
        : base(id, firstName, lastName)
    {
        SpyNumber = spyNumber;
    }

    public int SpyNumber { get ; set; }

    public override string ToString()
    {
        return base.ToString()+$"{Environment.NewLine}Code Number: {SpyNumber}";
    }
}

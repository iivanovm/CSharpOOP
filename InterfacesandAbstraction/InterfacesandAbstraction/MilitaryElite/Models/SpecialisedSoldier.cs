namespace MilitaryElite.Models;
using MilitaryElite.Enums;


public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    public SpecialisedSoldier()
    {
        
    }

    public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary)
        :base(id, firstName, lastName, salary)
    {
       
    }
    public ECorps ECorps { get; set; }

    public override string ToString()
    {
        return base.ToString();
    }
}

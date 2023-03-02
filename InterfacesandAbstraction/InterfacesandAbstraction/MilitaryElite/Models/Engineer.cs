namespace MilitaryElite.Models;
using Interfaces;
using Enums;


public class Engineer : SpecialisedSoldier, IEngineer
{

    public Engineer(int id, string firstName, string lastName, decimal salary, ECorps corps,ICollection<SRepair> repairs)
        : base(id, firstName, lastName, salary)
    {
        Repairs = repairs;
        Corps = corps;
    }

    public ECorps Corps { get; set; }
    public ICollection<SRepair> Repairs { get; set; }

    public override string ToString()
    {

        return base.ToString()+$"{Environment.NewLine}Corps: {Corps}{Environment.NewLine}Repairs:{Environment.NewLine}{string.Join(Environment.NewLine,Repairs)}";

    }
}

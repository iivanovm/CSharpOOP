using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public ICollection<IPrivate> privates { get; set; }
    public LeutenantGeneral()
    {
        
    }

    public LeutenantGeneral(int id, string firstName, string lastName, decimal salary,ICollection<IPrivate> privates)
        : base(id, firstName, lastName, salary)
    {
        this.privates = privates;
    }

    public override string ToString()
    {
        if(this.privates.Count == 0)
        {
            return base.ToString() + $"{Environment.NewLine}Privates:";
        }
        return base.ToString()+$"{Environment.NewLine}Privates:{Environment.NewLine}{string.Join(Environment.NewLine, privates)}";
    }
}

namespace MilitaryElite.Models.Interfaces;

public interface ILeutenantGeneral:IPrivate
{
    ICollection<IPrivate> privates { get; set; }
}

namespace MilitaryElite;
using Models.Interfaces;
using Enums;

public interface ISpecialisedSoldier:IPrivate
{
     ECorps ECorps { get; set; }
}

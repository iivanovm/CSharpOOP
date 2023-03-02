namespace MilitaryElite.Models.Interfaces;

public interface IEngineer:ISpecialisedSoldier
{
    ICollection<SRepair> Repairs { get; set; }
}

using MilitaryElite.Enums;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando()
        {
            Missions = new HashSet<SMission>();
        }

        public Commando(int id, string firstName, string lastName, decimal salary, ECorps cCorps, ICollection<SMission> sMissions)
            : base(id, firstName, lastName, salary)
        {
            Missions = sMissions;
            CCorps = cCorps;
        }

        public ECorps CCorps { get; set; }


        public ICollection<SMission> Missions { get; set; }

        public void CompleteMission()
        {

        }

        public override string ToString()
        {
            if (Missions.Count > 0)
            {
                return base.ToString() + $"{Environment.NewLine}Corps: {CCorps}{Environment.NewLine}Missions:{Environment.NewLine}{string.Join(Environment.NewLine, Missions)}";
            }
            return base.ToString() + $"{Environment.NewLine}Corps: {CCorps}{Environment.NewLine}Missions:";
        }
    }
}

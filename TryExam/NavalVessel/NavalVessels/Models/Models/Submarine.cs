using NavalVessels.Models.Contracts;
using System.Text;

namespace NavalVessels.Models.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double InitialArmorThickness = 200;
        private const double MainWeaponCaliberChange = 40;
        private const double SpeedChange = 4;

        public Submarine(string name, double mainWeaponCaliber, double speed)
           : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
            SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }

        public void ToggleSubmergeMode()
        {
            if (!SubmergeMode)
            {
                MainWeaponCaliber += MainWeaponCaliberChange;
                Speed -= SpeedChange;
            }
            else
            {
                MainWeaponCaliber -= MainWeaponCaliberChange;
                Speed += SpeedChange;
            }

            SubmergeMode = !SubmergeMode;
        }

        public override void RepairVessel()
        {
            ArmorThickness = InitialArmorThickness;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string submergeModeOnOff = SubmergeMode ? "ON" : "OFF";

            sb
                .AppendLine(base.ToString())
                .AppendLine($" *Submerge mode: {submergeModeOnOff}");
            return sb.ToString().TrimEnd();
        }
    }
}

using NavalVessels.Models.Contracts;
using System.Text;

namespace NavalVessels.Models.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double InitialArmorThickness = 300;
        private const double MainWeaponCaliberChange = 40;
        private const double SpeedChange = 5;

        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
            SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public void ToggleSonarMode()
        {
            if (!SonarMode)
            {
                MainWeaponCaliber += MainWeaponCaliberChange;
                Speed -= SpeedChange;
            }
            else
            {
                MainWeaponCaliber -= MainWeaponCaliberChange;
                Speed += SpeedChange;
            }

            //Flip mode -> Toggle
            //False -> True
            //True -> False
            SonarMode = !SonarMode;
        }

        public override void RepairVessel()
        {
            ArmorThickness = InitialArmorThickness;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string sonarModeOnOff = SonarMode ? "ON" : "OFF";

            sb
                .AppendLine(base.ToString())
                .AppendLine($" *Sonar mode: {sonarModeOnOff}");
            return sb.ToString().TrimEnd();
        }
    }
}

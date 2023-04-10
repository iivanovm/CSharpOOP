using System.Diagnostics;

namespace PlanetWars.Models.Weapons.Entities
{
    public class NuclearWeapon : Weapon
    {
        private const double NucPrice = 15;

        public NuclearWeapon(int destructionLevel)
            : base(NucPrice, destructionLevel)
        {
        }
    }
}

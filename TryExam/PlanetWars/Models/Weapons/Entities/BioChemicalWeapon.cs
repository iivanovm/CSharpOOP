using System.Diagnostics;

namespace PlanetWars.Models.Weapons.Entities
{
    public class BioChemicalWeapon : Weapon
    {
        private const double BioPrice = 3.2;
        public BioChemicalWeapon(int destructionLevel) : base(BioPrice, destructionLevel)
        {

        }
    }
}

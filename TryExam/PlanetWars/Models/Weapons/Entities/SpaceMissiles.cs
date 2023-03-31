namespace PlanetWars.Models.Weapons.Entities
{
    public class SpaceMissiles : Weapon
    {
        private const double SpacePrice = 8.75;
        public SpaceMissiles(int destructionLevel)
            : base(SpacePrice,destructionLevel)
        {
        }
    }
}

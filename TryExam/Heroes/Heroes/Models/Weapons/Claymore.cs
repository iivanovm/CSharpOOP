namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        private const int ClaymoreDamage = 25;
        public Claymore(string name, int durability) 
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            Durability--;
            return Durability == 0 ? 0 : ClaymoreDamage;
        }
    }
}

namespace ChristmasPastryShop.Models.Cocktails.Models
{
    public class Hibernation : Cocktail
    {

		private const double basePriceHibernation = 10.50;

		public Hibernation(string cocktailName, string size) : base(cocktailName, size, basePriceHibernation)
        {
        }
    }
}

namespace ChristmasPastryShop.Models.Cocktails.Models
{
    public class MulledWine : Cocktail
    {
		private const double mulledWineBasePrice = 13.50;
        public MulledWine(string cocktailName, string size) : base(cocktailName, size, mulledWineBasePrice)
        {
        }
    }
}

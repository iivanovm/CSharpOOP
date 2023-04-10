namespace FoodShortage.Models.Interfaces
{
    public interface IBuyer
    {
        protected int Food { get; }

        void BuyFood();
    }
}

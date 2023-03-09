using WildFarm.Models.interfaces;

namespace WildFarm.Models;

public abstract class Food : IFood
{
    public int Quantity { get; protected set; }

    protected Food(int quantity)
    {
        Quantity = quantity;
    }
}

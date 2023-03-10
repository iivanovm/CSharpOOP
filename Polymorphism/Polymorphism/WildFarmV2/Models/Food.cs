using WildFarmV2.Models.interfaces;

namespace WildFarmV2.Models;

public abstract class Food : IFood
{
    public int Quantity { get; protected set; }

    protected Food(int quantity)
    {
        Quantity = quantity;
    }
}

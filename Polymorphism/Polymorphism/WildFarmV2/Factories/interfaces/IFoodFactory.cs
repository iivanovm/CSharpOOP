using WildFarm.Models;
using WildFarm.Models.interfaces;

namespace WildFarm.Factories.interfaces;

public interface IFoodFactory
{
    IFood CreateFood(string type, int quantity);
}

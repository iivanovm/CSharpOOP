using WildFarmV2.Models;
using WildFarmV2.Models.interfaces;

namespace WildFarmV2.Factories.interfaces;

public interface IFoodFactory
{
    IFood CreateFood(string type, int quantity);
}

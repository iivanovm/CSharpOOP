﻿namespace WildFarmV2;

using Models.interfaces;
using Factories.interfaces;
using Models.Foods;

public class FoodFactory : IFoodFactory
{
    public IFood CreateFood(string type, int quantity)
    {
        switch (type)
        {
            case "Vegetable":
                return new Vegetable(quantity);
            case "Fruit":
                return new Fruit(quantity);
            case "Meat":
                return new Meat(quantity);
            case "Seeds":
                return new Seeds(quantity);
            default:
                throw new ArgumentException("Invalid food type!");
        }
    }
}

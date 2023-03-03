﻿using WildFarm.Models.AbstractCl;

namespace WildFarm.Models;

public class Mouse : Mammal
{
    public Mouse(string name, double weight, int foodEaten, string livingRegion) 
        : base(name, weight, foodEaten, livingRegion)
    {
    }

    public override string ProduceSound() => "Squeak";
}

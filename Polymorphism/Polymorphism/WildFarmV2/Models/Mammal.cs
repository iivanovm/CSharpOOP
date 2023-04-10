using WildFarmV2.Models.interfaces;

namespace WildFarmV2.Models;

public abstract class Mammal : Animal, IMammal
{
    public string LivinigRegion { get; protected set; }
    protected Mammal(string animalName, double animalWeight,string livingRegion) 
        : base(animalName, animalWeight)
    {
        LivinigRegion = livingRegion;
    }


}
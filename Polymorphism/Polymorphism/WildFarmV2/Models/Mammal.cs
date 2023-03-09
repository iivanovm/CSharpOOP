using WildFarm.Models.interfaces;

namespace WildFarm.Models;

public abstract class Mammal : Animal, IMammal
{
    public string LivinigRegion { get; protected set; }
    protected Mammal(string animalName, double animalWeight,string livingRegion) 
        : base(animalName, animalWeight)
    {
        LivinigRegion = livingRegion;
    }


}
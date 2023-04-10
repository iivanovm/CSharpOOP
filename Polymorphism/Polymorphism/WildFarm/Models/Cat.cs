using System.Runtime.CompilerServices;
using WildFarm.Models.AbstractCl;
using WildFarm.Models.Struct;

namespace WildFarm.Models;

public class Cat : Feline
{
    private const double animalWplus1 = 0.30;

    public Cat(string name, double weight, int foodEaten, string livingRegion, string breed) :
        base(name, weight, foodEaten, livingRegion, breed,animalWplus1)
    {
    }

    protected double WingSize { get; set; }
    
   
  

    public override string ProduceSound() => "Meow";
}

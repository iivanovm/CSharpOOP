namespace Vehicles.Models;

public class Bus : Vehicle
{

    private const double AirCond = 1.4;

    public Bus(double fuelQuantity, double consumptionPerKm, double tankCapacity) :
        base(fuelQuantity, consumptionPerKm , tankCapacity,AirCond)
    {
        
    }
}

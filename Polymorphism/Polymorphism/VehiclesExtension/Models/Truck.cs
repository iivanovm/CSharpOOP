namespace Vehicles.Models;

public class Truck : Vehicle

{
    private const double AirConD=1.6;
    private const double FuelLimit = 0.95;

    public Truck(double fuelQuantity, double consumptionPerKm, double tankCapacity) 
        : base(fuelQuantity, consumptionPerKm, tankCapacity,AirConD)
    {
        base.RefFuelQuantityLimit = FuelLimit;
    }
}

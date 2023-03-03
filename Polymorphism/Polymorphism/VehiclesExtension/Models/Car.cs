namespace Vehicles.Models;

public class Car : Vehicle
{
    private const double AirCon = 0.9;

    public Car(double fuelQuantity, double consumptionPerKm, double tankCapacity) 
        : base(fuelQuantity, consumptionPerKm+AirCon, tankCapacity)
    {
    }
}

   

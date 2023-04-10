namespace Vehicles.Models;

public class Bus : Vehicle
{

     private double AirConditions { get; set; }

    public Bus(double fuelQuantity, double consumptionPerKm) 
        : base(fuelQuantity, consumptionPerKm)
    {

    }



}

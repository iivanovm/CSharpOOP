namespace Vehicles.Models;

public class Bus : Vehicle
{

    private const double AirCond = 1.4;

    public Bus(double fuelQuantity, double consumptionPerKm, double tankCapacity) :
        base(fuelQuantity, consumptionPerKm + AirCond, tankCapacity)
    {

    }
    public void DriveEmpty(double Distance)
    {
        if (FuelQuantity < (Distance * ConsumptionPerKm))
        {
            Console.WriteLine($"{GetType().Name} needs refueling");
        }
        else
        {
            Console.WriteLine($"{GetType().Name} travelled {Distance} km");
            FuelQuantity -= Distance * ConsumptionPerKm-AirCond;
        }
    }

}

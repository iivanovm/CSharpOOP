using Vehicles.Models.interfaces;

namespace Vehicles.Models;

public abstract class Vehicle : IVehicle
{

    protected Vehicle(double fuelQuantity, double consumptionPerKm)
    {
        FuelQuantity = fuelQuantity;
        ConsumptionPerKm = consumptionPerKm;
        RefFuelQuantityLimit = 1;
    }

    public double FuelQuantity { get; private set; }

    public double ConsumptionPerKm { get; private set; }

    protected double RefFuelQuantityLimit { get; set; }

    public  void Drive(double Distance)
    {
        if (FuelQuantity < (Distance * ConsumptionPerKm))
        {
            Console.WriteLine($"{GetType().Name} needs refueling");
        }
        else
        {
            Console.WriteLine($"{GetType().Name} travelled {Distance} km");
            FuelQuantity -= Distance * ConsumptionPerKm;
        }
    }



    public void Refuel(double Litters)
    {
        FuelQuantity += Litters*RefFuelQuantityLimit;
    }

    public override string ToString()
    {
        return $"{GetType().Name}: {FuelQuantity:f2}";
    }
}

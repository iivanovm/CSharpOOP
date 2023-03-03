using Vehicles.Models.interfaces;

namespace Vehicles.Models;

public abstract class Vehicle : IVehicle
{

    private double tankCapacity;
    private double fuelQuantity;
    private double consumptionPerKm;
    protected double airCon;
    protected Vehicle(double fuelQuantity, double consumptionPerKm, double tankCapacity,double airCon)
    {
        FuelQuantity = fuelQuantity;
        ConsumptionPerKm = consumptionPerKm;
        TankCapacity = tankCapacity;
        RefFuelQuantityLimit = 1;
        AirCon=airCon;
    }



    public double FuelQuantity
    {
        get { return fuelQuantity; }
        protected set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            fuelQuantity = value;
        }
    }
    public double ConsumptionPerKm
    {
        get { return consumptionPerKm; }
        private set
        {
            if (value <= 0)
            {
                consumptionPerKm = 0;
            }
            consumptionPerKm = value;
        }
    }
    protected double RefFuelQuantityLimit { get; set; }
    public double TankCapacity
    {
        get { return tankCapacity; }
        private set
        {
            if (fuelQuantity > value)
            {
                fuelQuantity = 0;
            }
            tankCapacity = value;
        }
    }
    protected double AirCon {
        get 
        {
            return airCon;
        }
        private set 
        { 
            airCon = value;
        }
    }


    public void Drive(double Distance)
    {
        if (FuelQuantity < (Distance * (ConsumptionPerKm+AirCon)))
        {
            Console.WriteLine($"{GetType().Name} needs refueling");
        }
        else
        {
            Console.WriteLine($"{GetType().Name} travelled {Distance} km");
            FuelQuantity -= Distance * (ConsumptionPerKm+AirCon);
        }
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
            FuelQuantity -= Distance * ConsumptionPerKm;
        }
    }
    public void Refuel(double Litters)
    {
        if (Litters <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
        }
        else if (FuelQuantity + Litters * RefFuelQuantityLimit > TankCapacity)
        {
            Console.WriteLine($"Cannot fit {Litters} fuel in the tank");
        }
        else
        {
            FuelQuantity += Litters * RefFuelQuantityLimit;
        }
    }



    public override string ToString()
    {
        return $"{GetType().Name}: {FuelQuantity:f2}";
    }
}

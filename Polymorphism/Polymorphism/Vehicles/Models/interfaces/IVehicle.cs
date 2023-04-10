namespace Vehicles.Models.interfaces
{
    public interface IVehicle
    {
 
        double FuelQuantity { get; }
        double ConsumptionPerKm { get; }

        void Drive(double Distance);
        void Refuel(double Litters);
    }
}

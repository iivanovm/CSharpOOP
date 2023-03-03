using Vehicles.Core.interfaces;
using Vehicles.IO;
using Vehicles.IO.interfaces;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        List<Vehicle> vehicles;

        public Engine()
        {
            reader = new ConsoleReader();
            writer = new ConsoleWriter();

            vehicles = new List<Vehicle>();
        }


        public void Start(IReader reader, IWriter writer)
        {
            try
            {
                int vehicleNum = 3;
                for (int i = 0; i < vehicleNum; i++)
                {
                    string[] currentVehicle = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (currentVehicle[0] == "Car")
                    {
                        vehicles.Add(new Car(double.Parse(currentVehicle[1]), double.Parse(currentVehicle[2]), double.Parse(currentVehicle[3])));
                    }
                    else if (currentVehicle[0] == "Truck")
                    {
                        vehicles.Add(new Truck(double.Parse(currentVehicle[1]), double.Parse(currentVehicle[2]), double.Parse(currentVehicle[3])));
                    }
                    else if (currentVehicle[0] == "Bus")
                    {
                        vehicles.Add(new Bus(double.Parse(currentVehicle[1]), double.Parse(currentVehicle[2]), double.Parse(currentVehicle[3])));
                    }
                }
                int commandNUm = int.Parse(reader.ReadLine());
                for (int command = 0; command < commandNUm; command++)
                {
                    string[] tokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string cmd = tokens[0];
                    string VehicleName = tokens[1];
                    double quantity = double.Parse(tokens[2]);
                    switch (cmd)
                    {
                        case "Drive":
                            vehicles.Where(x => x.GetType().Name == VehicleName).FirstOrDefault().Drive(quantity);
                            break;
                        case "Refuel":
                            vehicles.Where(x => x.GetType().Name == VehicleName).FirstOrDefault().Refuel(quantity);
                            break;
                        case "DriveEmpty":
                            vehicles.Where(x => x.GetType().Name == VehicleName).FirstOrDefault().DriveEmpty(quantity);
                            break;
                    }
                }
                Print(vehicles);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void Print(List<Vehicle> vehicles)
        {
            Console.WriteLine($"Car: {vehicles.Where(x => x.GetType().Name == "Car").FirstOrDefault().FuelQuantity:f2}");
            Console.WriteLine($"Truck: {vehicles.Where(x => x.GetType().Name == "Truck").FirstOrDefault().FuelQuantity:f2}");
            Console.WriteLine($"Bus: {vehicles.Where(x => x.GetType().Name == "Bus").FirstOrDefault().FuelQuantity:f2}");

        }
    }
}

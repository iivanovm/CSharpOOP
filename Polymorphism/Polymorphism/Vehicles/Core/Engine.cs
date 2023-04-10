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
            int vehicleNum = 2;
            for (int i = 0; i < vehicleNum; i++)
            {
                string[] currentVehicle = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (i % 2 == 0)
                {
                    vehicles.Add(new Car(double.Parse(currentVehicle[1]), double.Parse(currentVehicle[2])));
                }
                else
                {
                    vehicles.Add(new Truck(double.Parse(currentVehicle[1]), double.Parse(currentVehicle[2])));
                }
            }
            int commandNUm = int.Parse(reader.ReadLine());
            for(int command=0; command<commandNUm; command++)
            {
                string[] tokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string cmd = tokens[0];
                string VehicleName = tokens[1];
                double quantity = double.Parse(tokens[2]);
                switch(cmd)
                {
                    case "Drive":
                        vehicles.Where(x => x.GetType().Name == VehicleName).FirstOrDefault().Drive(quantity);
                        break;
                    case "Refuel":
                        vehicles.Where(x => x.GetType().Name == VehicleName).FirstOrDefault().Refuel(quantity);
                        break;
                }
            }
            vehicles.ForEach(x => writer.WriteLine(x.ToString()));
        }
    }
}

using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Repositories.Contracts;
using EDriveRent.Utilities.Messages;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IUser> users;
        private readonly IRepository<IVehicle> vehicles;
        private readonly IRepository<IRoute> routes;
        private string[] validVehicle = Utils.GetChildClassNames(typeof(Vehicle)).ToArray();

        public Controller()
        {
            users = new UserRepository();
            vehicles = new VehicleRepository();
            routes = new RouteRepository();
        }


        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            if (routes.GetAll().FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length == length) != null)
            {
                return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
            }
            if (routes.GetAll().FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length < length) != null)
            {
                return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
            }
            IRoute route = new Route(startPoint, endPoint, length, routes.GetAll().Count + 1);
            routes.AddModel(route);
            if (routes.GetAll().FirstOrDefault(x => x.StartPoint == startPoint && x.EndPoint == endPoint && x.Length > length) != null)
            {
                routes.GetAll().FirstOrDefault(x => x.StartPoint == startPoint && x.EndPoint == endPoint && x.Length > length).LockRoute();
            }
            return $"{startPoint}/{endPoint} - {length} km is unlocked in our platform.";
        }
        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            if (users.GetAll().Where(u => u.DrivingLicenseNumber == drivingLicenseNumber).Count() != 0)
            {
                return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }
            IUser user = new User(firstName, lastName, drivingLicenseNumber);
            users.AddModel(user);
            return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
        }
        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            string stName = $"EDriveRent.Models.{vehicleType}";
            if (!validVehicle.Contains(vehicleType))
            {
                return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }
            if (vehicles.GetAll().Where(v => v.LicensePlateNumber == licensePlateNumber).Count() > 0)
            {
                return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }
            IVehicle vehicle;
            if (vehicleType == "PassengerCar")
            {
                vehicle = new PassengerCar(brand, model, licensePlateNumber);
            }
            else
            {
                vehicle = new CargoVan(brand, model, licensePlateNumber);
            }
            vehicles.AddModel(vehicle);
            return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
        }
        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            IUser user = users.FindById(drivingLicenseNumber);
            IVehicle vehicle = vehicles.FindById(licensePlateNumber);
            IRoute route = routes.FindById(routeId);


            if (user.IsBlocked)
            {
                return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
            }
            if (vehicle.IsDamaged)
            {
                return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
            }
            if (route.IsLocked)
            {
                return string.Format(OutputMessages.RouteLocked, routeId);
            }
            vehicle.Drive(route.Length);
            if (isAccidentHappened)
            {
                if (!vehicle.IsDamaged)
                {
                    vehicle.ChangeStatus();
                }
                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }

            return vehicle.ToString();
        }
        public string RepairVehicles(int count)
        {
            var damageV = vehicles.GetAll().Where(v => v.IsDamaged).ToList().OrderBy(v => v.Brand).ThenBy(v => v.Model).Take(count);

            int cnt = 0;

            damageV.ToList().ForEach(v =>
                {
                    v.Recharge();
                    v.ChangeStatus();
                    cnt++;
                });
            return string.Format(OutputMessages.RepairedVehicles, cnt);
        }


        public string UsersReport()
        {
            var usrs = users.GetAll().OrderByDescending(u => u.Rating).ThenBy(us => us.LastName).ThenBy(usr => usr.FirstName).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*** E-Drive-Rent ***");
            foreach (var user in usrs)
            {
                sb.AppendLine(user.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}

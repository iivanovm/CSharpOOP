using Gym.Core.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Models.Gyms.Models;
using Gym.Repositories.Models;
using Gym.Utilities;
using System.Collections.Generic;
using System.Linq;
using System;
using Gym.Utilities.Messages;
using Gym.Models.Equipment.Models;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Athletes.Models;
using Gym.Models.Athletes.Contracts;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipments;
        private List<IGym> gyms;
        private string[] validGymType = Validation.GetChildClassNames(typeof(Gym.Models.Gyms.Models.Gym)).ToArray();
        private string[] validEquipmentType=Validation.GetChildClassNames(typeof(Equipment)).ToArray();
        private string[] validAthleteType=Validation.GetChildClassNames(typeof(Athlete)).ToArray();

        public Controller()
        {
            equipments = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddGym(string gymType, string gymName)
        {
            if (!validGymType.Contains(gymType))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
            IGym gym;
            if(gymType== "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else
            {
                gym = new WeightliftingGym(gymName);
            }
            gyms.Add(gym);
            
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }
        public string AddEquipment(string equipmentType)
        {
            if (!validEquipmentType.Contains(equipmentType))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
            IEquipment equipment;
            if(equipmentType== "BoxingGloves")
            {
                equipment = new BoxingGloves();
            }
            else
            {
                equipment = new Kettlebell();
            }
            equipments.Add(equipment);

            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }
        public string InsertEquipment(string gymName, string equipmentType)
        {
            if(equipments.FindByType(equipmentType) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
            IGym gym= gyms.FirstOrDefault(g=>g.Name==gymName);
            IEquipment equipment= equipments.FindByType(equipmentType);
            gym.AddEquipment(equipment);
            equipments.Remove(equipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete;
            IGym gym=gyms.FirstOrDefault(g=>g.Name==gymName);
            

            if (!validAthleteType.Contains(athleteType))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }
            if(athleteType== "BoxingGym")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else
            {
                athlete = new Weightlifter(athleteName,motivation, numberOfMedals);
            }
            var gymType = gyms.FirstOrDefault(x => x.Name == gymName).GetType().Name;
            var currGym = gyms.FirstOrDefault(x => x.Name == gymName);

            if (gymType == "BoxingGym"&&athleteType=="Boxer")
            {
                currGym.AddAthlete(athlete);
            }
            else if (gymType == "WeightliftingGym"&&athleteType== "Weightlifter")
            {
                currGym.AddAthlete(athlete);
            }
            else
            {
                return "The gym is not appropriate.";
            }

            return $"Successfully added {athleteType} to {gymName}.";
        }
        public string TrainAthletes(string gymName)
        {
            IGym currGym = gyms.FirstOrDefault(x => x.Name == gymName);
            currGym.Exercise();

            return $"Exercise athletes: {currGym.Athletes.Count}.";
        }
        public string EquipmentWeight(string gymName)
        {
            IGym currGym = gyms.FirstOrDefault(x => x.Name == gymName);
            return $"The total weight of the equipment in the gym {gymName} is {currGym.EquipmentWeight:f2} grams.";
        }
        public string Report()
        {
            var builder = new StringBuilder();

            foreach (var gym in gyms)
            {
                builder.AppendLine(gym.GymInfo());
            }

            return builder.ToString().TrimEnd();
        }
    }
}
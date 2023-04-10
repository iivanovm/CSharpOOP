using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms.Models
{
    public abstract class Gym : IGym
    {
        private string name;
        private List<IEquipment> equipments;
        private List<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            equipments = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value;
            }
        }
        public int Capacity
        {
            get; protected set;
        }
        public double EquipmentWeight
        {
            get
            {
                return equipments.Sum(x => x.Weight);
            }
        }

        public ICollection<IEquipment> Equipment => equipments;
        public ICollection<IAthlete> Athletes => athletes;
        public void AddAthlete(IAthlete athlete)
        {
            if(athletes.Count<=Capacity)
            {
                athletes.Add(athlete);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
        }
        public void AddEquipment(IEquipment equipment) => equipments.Add(equipment);
        public void Exercise() => athletes.ForEach(x => x.Exercise());
        public string GymInfo()
        {
            var builder = new StringBuilder();

            builder.AppendLine($"{Name} is a {GetType().Name}");
            builder.AppendLine($"Athletes: {(Athletes.Any() ? string.Join(", ", Athletes.Select(x => x.FullName)) : "No athletes")}");
            builder.AppendLine($"Equipment total count: {Equipment.Count}");
            builder.AppendLine($"Equipment total weight: {Equipment.Sum(x => x.Weight):f2} grams");

            return builder.ToString().TrimEnd();
        }
        public bool RemoveAthlete(IAthlete athlete) => Athletes.Remove(athlete);
    }
}

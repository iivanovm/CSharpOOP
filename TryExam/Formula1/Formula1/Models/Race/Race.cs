using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using Formula1.Models;
using System.Text;

namespace Formula1.Models.Race
{
    public class Race : IRace
    {

        private string raceName;
        private int numberOfLaps;
        private bool tookPlace;
        private ICollection<IPilot> Pilots;

        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            Pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get => raceName;
            private set
            {
                if(string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers,value));
                }
                raceName = value;
            }
        }
        public int NumberOfLaps
        {
            get => numberOfLaps;
           private set 
            { 
                if(value<1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                numberOfLaps = value; 
            }
        }
        public bool TookPlace 
        {
            get; set;
        }


        ICollection<IPilot> IRace.Pilots => Pilots;

        public void AddPilot(IPilot pilot)=>Pilots.Add(pilot);

        public string RaceInfo()
        {
            StringBuilder ri = new StringBuilder();
            ri.AppendLine($"The {RaceName} race has:)")
                .AppendLine($"Participants: {Pilots.Count}")
                .AppendLine($"Number of laps: {NumberOfLaps}")
                .AppendLine($"Took place: {(TookPlace ? "Yes" : "No")}");

            return ri.ToString().Trim();
        }
    }
}

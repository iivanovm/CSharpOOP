using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;

namespace Formula1.Models.Pilot
{
    public class Pilot : IPilot
    {
        private string fullName;
        private bool canRace;
        private IFormulaOneCar car;
        private int numberOfWins;
        private List<IFormulaOneCar> cars;


        public Pilot(string fullName)
        {
            FullName = fullName;
            cars = new List<IFormulaOneCar>();
        }


        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(fullName) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }
                fullName = value;
            }
        }
        public bool CanRace
        {
            get; private set;
        }
        public IFormulaOneCar Car
        {
            get => car;
            private set
            {
                if (car == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }
                car = value;
            }
        }
        public int NumberOfWins
        {
            get => numberOfWins;
            private set
            {
                numberOfWins = value;
            }
        }


        public void AddCar(IFormulaOneCar car) => cars.Add(car);
        public void WinRace()=>NumberOfWins++;
        public override string ToString() => $"Pilot {FullName} has {numberOfWins} wins.";
    }
}

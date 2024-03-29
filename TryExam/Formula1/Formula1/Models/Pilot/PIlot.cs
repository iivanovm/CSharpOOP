﻿using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;

namespace Formula1.Models.Pilot
{
    public class Pilot : IPilot
    {
        private string fullName;
        private bool canRace;
        private int numberOfWins;
        IFormulaOneCar car;

        public Pilot(string fullName)
        {
            FullName = fullName;
            canRace = false;
            NumberOfWins = 0;
        }

        public string FullName
        {
            get
            {
                return fullName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid pilot name: {value}.");
                }
                fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get
            {
                return car;
            }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot car can not be null.");
                }
                car = value;
            }
        }

        public int NumberOfWins
        {
            get
            {
                return numberOfWins;
            }
            private set
            {
                numberOfWins = value;
            }
        }
        public bool CanRace
        {
            get
            {
                return canRace;
            }
            private set
            {
                canRace = value;
            }
        }

        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            CanRace = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {FullName} has {NumberOfWins} wins.";
        }
    }
}

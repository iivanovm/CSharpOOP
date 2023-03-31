using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;


namespace PlanetWars.Models.Weapons.Entities
{
    public class Weapon : IWeapon
    {
        private double price;
        private int destructionLevel;

        protected Weapon(double price,int destructionLevel )
        {
            Price = price;
            DestructionLevel = destructionLevel;
        }

        public double Price
        {
            get => price;
            private set => price = value;
        }
        public int DestructionLevel
        {
            get => destructionLevel;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                }
                if (value > 10)
                {
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
                }
                destructionLevel = value;
            }
        }

    }
}

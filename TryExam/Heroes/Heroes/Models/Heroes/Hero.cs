using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon ;
        private bool isAlive;

        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public string Name
        {
            get => name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HeroNameNull);
                }
                name = value;
            }
        }
        public int Health
        {
            get => health;
            private set 
            {
                if (health < 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeroHealthBelowZero);
                }
                health = value; 
            }
        }
        public int Armour
        {
            get => armour;
            private set 
            { 
                if(armour < 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeroArmourBelowZero);
                }
                armour = value; 
            }
        }
        public IWeapon Weapon 
        {
            get => weapon;
            private set
            {if(value is null)
                {
                    throw new ArgumentException(ExceptionMessages.WeaponNull);
                }

                weapon = value;
            }
        }
        public bool IsAlive
        {
            get => isAlive;
            private set 
            { 
                if(health<=0)
                {
                    isAlive = true;
                }
            }
        }



        public void AddWeapon(IWeapon weapon) => this.weapon = weapon;

        public void TakeDamage(int points)
        {
            if (Armour > 0)
            {
                Armour -= points;
                if (Armour < 0)
                {
                    points = -Armour;
                    Armour = 0;
                }
                else
                {
                    points = 0;
                }
            }

            Health -= points;
        }
    }
}

using Gym.Utilities.Messages;
using System;

namespace Gym.Models.Athletes.Models
{
    public class Weightlifter : Athlete
    {
        public Weightlifter(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, numberOfMedals, 50)
        {
        }

        public override void Exercise() => this.Stamina += 10 > 100 ? throw new ArgumentException(ExceptionMessages.InvalidStamina) : Stamina += 10;
    }
}

namespace Gym.Models.Gyms.Models
{
    public class WeightliftingGym : Gym
    {
        private const int LiftingGymCapacity = 20;

        public WeightliftingGym(string name ) 
            : base(name, LiftingGymCapacity)
        {
        }
    }
}

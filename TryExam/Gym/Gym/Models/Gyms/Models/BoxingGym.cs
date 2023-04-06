namespace Gym.Models.Gyms.Models
{
    public class BoxingGym : Gym
    {
        private const int BoxCapacity = 15;
        public BoxingGym(string name) 
            : base(name, BoxCapacity)
        {
        }
    }
}

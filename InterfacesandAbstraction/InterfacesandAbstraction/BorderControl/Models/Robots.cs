using BorderControl.Models.Interfaces;

namespace BorderControl.Models
{
    public class Robots : IRobot
    {
        public Robots(string name, string id)
        {
            Name = name;
            Id = id;
        }
        public Robots()
        {
            
        }

        public string Name { get; set; }

        public string Id { get; set; }
    }
}

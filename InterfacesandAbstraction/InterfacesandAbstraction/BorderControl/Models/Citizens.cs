namespace BorderControl.Models
{
    using Interfaces;
    public class Citizens : ICitizen
    {
        public Citizens(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public Citizens()
        {
            
        }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }
    }
}

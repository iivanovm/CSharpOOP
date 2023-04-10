namespace BorderControl.Models
{
    using BirthdayCelebrations.Models.Interfaces;
    using Interfaces;
    public class Citizens : ICitizen
    {
        public Citizens(string name, int age, string id, string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = birthday;
        }

        public Citizens()
        {
            
        }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }
        public string Birthday { get; set; }
    }
}

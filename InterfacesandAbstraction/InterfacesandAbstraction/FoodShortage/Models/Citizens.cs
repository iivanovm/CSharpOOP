namespace BorderControl.Models
{
    using BirthdayCelebrations.Models.Interfaces;
    using FoodShortage.Models.Interfaces;
    using Interfaces;
    public class Citizens : ICitizen,IBuyer
    {
        private int food;

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
        public int Food 
        {
            get
            {
                return food;
            }
            private set
            {
               food=value;
            }
        }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}

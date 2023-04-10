using BirthdayCelebrations.Models.Interfaces;

namespace BorderControl.Models.Interfaces
{
    public interface ICitizen : IPerson,IBerthdable
    {
        public int Age { get; set; }
    }
}

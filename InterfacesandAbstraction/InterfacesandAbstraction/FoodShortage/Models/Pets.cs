namespace BirthdayCelebrations;
using Models.Interfaces;

public class Pets : IPet
{
    public Pets( string name, string birthday)
    {
        Name = name;
        Birthday = birthday;
    }

    public string Name { get; set; }
    public string Birthday { get; set; }
    public string Id { get;  set; }
}

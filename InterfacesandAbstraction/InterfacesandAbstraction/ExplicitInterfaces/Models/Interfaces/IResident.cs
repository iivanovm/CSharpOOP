namespace ExplicitInterfaces.Models.Interfaces;

public interface IResident
{
    string Name { get; }
    string Country { get; }

    void GetName() =>Console.WriteLine($"Mr/Ms/Mrs {Name}");
    
}

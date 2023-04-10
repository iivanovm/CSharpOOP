namespace ExplicitInterfaces.Models.Interfaces;

public interface IPerson
{
    string Name { get; }
    int Age { get; }

    void GetName() => Console.WriteLine(Name);
    
}

using CustomStack;

public class StartUp
{
    public static void Main()
    {
        StackOfStrings strings = new StackOfStrings();
        strings.AddRange(new List<string> { "iivan", "Pesho", "Gosho", "Dimitrichko" });
        while (!strings.IsEmptry())
        {
            Console.WriteLine(strings.Pop());
        }
    }
}
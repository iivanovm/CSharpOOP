using PersonsInfo;

public class StartUp
{
    public static void Main()
    {
        Team team = new Team("SoftUni");
        int num=int.Parse(Console.ReadLine());
        List<Person> persons= new List<Person>();
        for(int i=0; i < num; i++)
        {
            string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            persons.Add(new Person(tokens[0], tokens[1], int.Parse(tokens[2]), decimal.Parse(tokens[3])));
        }

        foreach (Person person in persons)
        {
            team.AddPlayer(person);
        }

        Console.WriteLine(team);

    }
}

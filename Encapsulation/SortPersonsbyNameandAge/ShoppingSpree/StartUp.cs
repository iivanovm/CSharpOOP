using ShoppingSpree;

public class StartUp
{
    public static void Main()
    {
        string[] human = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
        string[] product = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
        List<Person> persons = new List<Person>();
        List<Product> products = new List<Product>();
        foreach (var item in human)
        {
            try
            {
                string[] tokens = item.Split("=");
                persons.Add(new Person(tokens[0], double.Parse(tokens[1])));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }
        }
        

        foreach (var item in product)
        {
            try
            {
                string[] tokens = item.Split("=");
                products.Add(new Product(tokens[0], double.Parse(tokens[1])));
            }
            catch (Exception e) 
            { 
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }
        }
        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            persons.Where(x => x.Name == input[0]).FirstOrDefault().Bought(products.Where(x => x.Name == input[1]).FirstOrDefault());
        }

        Console.WriteLine(string.Join(Environment.NewLine, persons));
    }
}
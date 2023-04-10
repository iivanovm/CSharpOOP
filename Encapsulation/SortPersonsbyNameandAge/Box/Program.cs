using Boxs;

public class StartUp
{
    public static void Main()
    {
        double leght = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height =double.Parse(Console.ReadLine());
        try
        {
            Box box = new Box(leght, width, height);
            Console.WriteLine(box);
        }
        catch (Exception e)
        {
            {
                Console.WriteLine(e.Message.ToString());
            }

        }
    }
}
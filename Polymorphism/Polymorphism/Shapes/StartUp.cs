namespace Shapes;
public class StartUp
{
    public static void Main()
    {
      List<Shape> shapes = new List<Shape>();

        shapes.Add(new Circle(10));
        shapes.Add(new Rectangle(40,50));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.Draw());
            Console.WriteLine("{0:0.000}", shape.CalculatePerimeter());
            Console.WriteLine("{0:0.000}", shape.CalculateArea());
            Console.WriteLine();
        }

    }
}

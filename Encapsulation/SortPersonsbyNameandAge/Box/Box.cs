using System.Text;

namespace Boxs;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public double Length
    {
        get
        {
            return length;
        }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Length)} cannot be zero or negative.");
            }
            length = value;
        }
    }
    public double Width
    {
        get
        {
            return width;
        }
        private set
        {
            if (value <= 0)
            {

                throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
            }
            width = value;
        }
    }
    public double Height
    {
        get
        {
            return height;
        }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
            }
            height = value;
        }
    }



    /*
     * Volume = lwh
        Lateral Surface Area = 2lh + 2wh
        Surface Area = 2lw + 2lh + 2wh
     * */
    private double SurfaceArea()
    {
        double surfaceArea = 2 * length * width + 2 * length * height + 2 * width * height;
        return surfaceArea;
    }

    private double LateralSurfaceArea()
    {
        return 2 * length * height + 2 * width * height;
    }

    private double Volume()
    {
        return length * width * height;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result
            .AppendLine($"Surface Area - {SurfaceArea():f2}")
            .AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}")
            .AppendLine($"Volume - {Volume():f2}");



        return result.ToString().Trim();
    }

}

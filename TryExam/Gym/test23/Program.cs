// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string test = "Car";

object o = InstanceWithParam(test);

Console.WriteLine(o.ToString());

static object CreateInstanceByClassName(string className)
{
    Type type = Type.GetType(className);
    if (type != null)
    {
        return Activator.CreateInstance(type);
    }
    else
    {
        throw new ArgumentException($"Could not create instance of class '{className}'.");
    }
}

static object CreateInstance(string className)
{
    Type classType = Type.GetType(className);
    if (classType == null)
    {
        throw new ArgumentException("Invalid class name specified.");
    }
    object instance = Activator.CreateInstance(classType);
    return instance;
}

static object InstanceWithParam(string test)
{
    Type t = Type.GetType(test);

    Object[] arg = { "Mercedes", 200 };

    Object o = Activator.CreateInstance(t, arg);
    return o;
}



public class Car
{

    public string Name { get; set; }
    public int HP { get; set; }
    public Car(string name, int hP)
    {
        Name = name;
        HP = hP;

    }

    public void Drive()
    {
        Console.WriteLine("Drive");
    }

    public override string ToString()
    {
        return $"Car {Name} have {HP} hoursepower.";
    }
}

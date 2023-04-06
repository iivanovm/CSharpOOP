using System;
using System.Dynamic;

namespace classrefl
{
    public class Program
    {
        static void Main()
        {
            string test = "Car";

            Type t = Type.GetType(test);

            Object[] args = { "Mercedes",200 };

            Object o = Activator.CreateInstance(t, args);
            Console.WriteLine(o.ToString());

        }


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

        public static object CreateInstance(string className)
        {
            Type classType = Type.GetType(className);
            if (classType == null)
            {
                throw new ArgumentException("Invalid class name specified.");
            }
            object instance = Activator.CreateInstance(classType);
            return instance;
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

            public override string ToString()
            {
                return $"Car {Name} have {HP} hoursepower.";
            }
        }

    }
}

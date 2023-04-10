using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person;

public class Person
{
    private string name;
    private int age;

    public string Name { get; set; }
    public int Age    {get;set;    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(String.Format($"Name: {Name}, Age: {Age}",
                             this.Name,
                             this.Age));

        return stringBuilder.ToString();
    }

}

﻿using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq;

public class Utils
{
    public static List<string> GetChildClassNames(Type parentClass)
    {

        List<Type> childClasses = Assembly.GetAssembly(parentClass)
            .GetTypes()
            .Where(type => type.IsSubclassOf(parentClass))
            .ToList();
        List<string> childClassNames = childClasses.Select(type => type.Name.Trim()).ToList();
        return childClassNames;
    }

    public static object CreateInstanceFromString(string className, params object?[]? param)
    {
        Type type = Type.GetType(className);
        if (type == null)
        {
            throw new ArgumentException($"Invalid class name: {className}");
        }
        return Activator.CreateInstance(type, param);
    }

    public static string clFullName(string className)
    {
        var tname = CreateInstanceFromString(className, null);

        return tname.GetType().FullName.ToString();
    }
}
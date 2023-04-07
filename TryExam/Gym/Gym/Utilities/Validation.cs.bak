using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace Gym.Utilities
{
    public class Validation
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

        public static Type CreateClass(string className)
        {

            AssemblyName assemblyName = new AssemblyName("DynamicAssembly");
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");
            TypeBuilder typeBuilder = moduleBuilder.DefineType(className, TypeAttributes.Public);
            Type newClass = typeBuilder.CreateType();

            return newClass;
        }

        public static object InstanceWithParam(string test)
        {
            Type t = Type.GetType(test);

            Object[] arg = { "Mercedes", 200 };

            Object o = Activator.CreateInstance(t, arg);
            return o;
        }

    }
}

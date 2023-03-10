using WildFarmV2.Init;
using WildFarmV2.Init.@interface;
using System.Collections.Generic;
using System.Reflection;
using WildFarmV2.IO.interfaces;
using WildFarmV2.IO;

public class StartUp
{
    public static void Main()
    {
        IInitialize init = new Initiazlize();
        init.Setup();
      //  getCombination();
    }

    static void getCombination()
    {
        List<MethodInfo> methodLis = new List<MethodInfo>();
        Queue<Type> types = new Queue<Type>();
        types.Enqueue(typeof(IWriter));
        types.Enqueue(typeof(IReader));
        while (types.Any())
        {
            Assembly.GetExecutingAssembly().GetTypes().Where(types.Dequeue().IsAssignableTo)
                .ToList()
                .ForEach(met =>
                {
                    MethodInfo[] currnet = met.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Default);
                    methodLis.AddRange(currnet);
                });
        }
        methodLis.ForEach(m=>Console.WriteLine(m.Name));
    }
}

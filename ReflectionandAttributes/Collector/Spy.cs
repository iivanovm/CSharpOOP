using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

public class Spy
{
    public string StealFieldInfo(string investigateClass, params string[] requestedFields)
    {
        Type classType = Type.GetType(investigateClass);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        StringBuilder result = new StringBuilder();
        Object classInstance = Activator.CreateInstance(classType, new object[] { });
        result.AppendLine($"Class under investigation: {investigateClass}");
        foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
        {
            result.AppendLine($"{field.Name}={field.GetValue(classInstance)}");
        }

        return result.ToString().Trim();
    }

    public string AnalyzeAccessModifiers(string investigateClass)
    {
        Type classType = Type.GetType(investigateClass);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder result = new StringBuilder();

        foreach (FieldInfo field in classFields)
        {
            result.AppendLine($"{field.Name} must be private!");
        }

        foreach (MethodInfo method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            result.AppendLine($"{method.Name} have to be public");
        }

        foreach (MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            result.AppendLine($"{method.Name} have to be private!");
        }

        return result.ToString().Trim();
    }

    public string RevealPrivateMethods(string investigatedClass)
    {
        Type classType = Type.GetType(investigatedClass);
        MethodInfo[] privateMethodInfos = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        //Object instanceClass = Activator.CreateInstance(classType);
        StringBuilder result = new StringBuilder();
        result.AppendLine($"All Private Methods of Class: {classType.Name}");
        result.AppendLine($"Base Class: {classType.BaseType}");
        foreach (MethodInfo method in privateMethodInfos)
        {
            result.AppendLine($"{method.Name}");
        }

        return result.ToString().Trim();
    }

    public string CollectGettersAndSetter(String investigatedClass)
    {
        Type ClassType= Type.GetType(investigatedClass);
        MethodInfo[] methodInfos = ClassType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic); 
        StringBuilder result = new StringBuilder();
        foreach (MethodInfo method in methodInfos.Where(m=>m.Name.StartsWith("get")))
        {
            result.AppendLine($"{method.Name} will return {method.ReturnType}");
        }
        foreach(MethodInfo method in methodInfos.Where(m => m.Name.StartsWith("set")))
        {
            result.AppendLine($"{method.Name} will set field of {method.ReturnType}");
        }

        return result.ToString().Trim();    
    }


}

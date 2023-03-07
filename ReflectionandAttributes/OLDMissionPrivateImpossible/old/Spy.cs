using System.Reflection;
using System.Security.Cryptography;
using System.Text;

public class Spy
{
    
    /*
     *It’s time to see what this hacker you are dealing with aims to do.
     * Create a method inside your Spy class called - RevealPrivateMethods(string className).
     * Print all private methods in the following format:
    All Private Methods of Class: {className}
    Base Class: {baseClassName}
    On the next lines, print found method’s names each on a new line. Use StringBuilder to concatenate the answer. 
    Don’t change anything in Hacker class! In your Main() method, you should be able to check your program with the current piece of code.

     *
     *
     *
     * All Private Methods of Class: Stealer.Hacker
Base Class: Object
get_Id
set_Id
set_BankAccountBalance
MemberwiseClone
Finalize

     */
    public string StealFieldInfo(string investigateClass, params string[] requestedFields)
    {
        Type classType = Type.GetType(investigateClass);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        StringBuilder result = new StringBuilder();
        Object classInstance = Activator.CreateInstance(classType, new object[] { });
        result.AppendLine($"Class under investigation: {investigateClass}");
        foreach (FieldInfo field in classFields.Where(f=>requestedFields.Contains(f.Name)))
        {
            result.AppendLine($"{field.Name}={field.GetValue(classInstance)}");
        }

        return result.ToString().Trim();
    }

    public string  AnalyzeAccessModifiers(string investigateClass)
    {
        Type classType= Type.GetType(investigateClass);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static| BindingFlags.Public);
        MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance| BindingFlags.NonPublic);
 
        StringBuilder result = new StringBuilder();

        foreach (FieldInfo field in classFields)
        {
            result.AppendLine($"{field.Name} must be private!");
        }

        foreach (MethodInfo method in classNonPublicMethods.Where(m=>m.Name.StartsWith("get")))
        {
            result.AppendLine($"{method.Name} have to be public");
        }

        foreach (MethodInfo method in classPublicMethods.Where(m=>m.Name.StartsWith("set")))
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
  
}

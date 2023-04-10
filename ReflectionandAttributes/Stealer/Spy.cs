using System.Reflection;
using System.Text;

public class Spy
{
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
}

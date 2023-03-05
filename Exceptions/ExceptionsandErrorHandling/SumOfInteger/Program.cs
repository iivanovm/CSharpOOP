using System.Numerics;

string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
int sum = 0;
foreach (string line in input)
{
    try
    {
        sum+=Check(line);
        Console.WriteLine($"Element \'{line}\' processed - current sum: {sum}");
    }
    catch(OverflowException a)
    {
        Console.WriteLine(a.Message);
        Console.WriteLine($"Element \'{line}\' processed - current sum: {sum}");
        continue;
    }
    catch(FormatException e)
    {
        Console.WriteLine(e.Message);
        Console.WriteLine($"Element \'{line}\' processed - current sum: {sum}");
        continue;
    }
}
Console.WriteLine($"The total sum of all integers is: {sum}");

int Check(string line)
{ 
    bool isInt = int.TryParse(line, out int value);
    bool isDouble = double.TryParse(line, out double result);
    bool isFloat = float.TryParse(line, out float dResult);
    bool isDecimal = decimal.TryParse(line, out decimal DResult);
    bool isBigInt = BigInteger.TryParse(line, out BigInteger bint);

    int.TryParse(line, out int intValue);
    if (isInt)
    {
        return intValue;
    }
    else 
    {
        if (isBigInt||value<0||result<0||dResult<0||DResult<0||bint<0)
        {
            throw new OverflowException($"The element '{line}' is out of range!");
        }
        else if(isDecimal || isFloat || isDouble)
        {
            throw new FormatException($"The element '{line}' is in wrong format!");
        }
        else
        {
            throw new FormatException($"The element '{line}' is in wrong format!");
        }
    }

    return intValue;
}

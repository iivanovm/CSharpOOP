int[] nums = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse).ToArray();
int count = 0;
while (count<3)
{
    try
    {
        string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string cmdType = command[0];
        if (cmdType == "Replace")
        {
            if (IsInt(command[1]) && IsInt(command[2]))
            {
                if (IsInRange(nums, int.Parse(command[1])))
                {
                    nums = Replace(nums, command[1], command[2]);
                }
                else
                {
                    throw new Exception("The index does not exist!");
                }
            }
            else
            {
                throw new Exception("The variable is not in the correct format!");
            }
        }
        else if (cmdType == "Print")
        {
            string startIndex = command[1];
            string endIndex = command[2];
            if (IsInt(startIndex) && IsInt(endIndex))
            {
                if (IsInRange(nums, int.Parse(startIndex)) && IsInRange(nums, int.Parse(endIndex)))
                {
                    Print(nums, startIndex, endIndex);
                }
                else
                {
                    throw new Exception("The index does not exist!");
                }
            }
            else
            {

                throw new Exception("The variable is not in the correct format!");
            }

        }
        else if (cmdType == "Show")
        {
            string index = command[1];
            if (IsInt(index))
            {
                if (IsInRange(nums, int.Parse(index)))
                {
                    Show(nums, index);
                }
                else
                {
                    throw new Exception("The index does not exist!");
                }
            }
            else
            {
                throw new Exception("The variable is not in the correct format!");
            }

        }
    }
    catch (Exception ae)
    {
        Console.WriteLine($"{ae.Message}");
        count++;
        continue;
    }
    
}
Console.WriteLine(string.Join(", ", nums));


bool IsInt(string input)
{
    int integer;
    return int.TryParse(input, out integer);
}

bool IsInRange(int[] ints, int startIndex)
{
    return startIndex > 0 && startIndex < ints.Length;
}

int[] Replace(int[] ints, string startIndex, string element)
{
    ints[int.Parse(startIndex)] = int.Parse(element);
    return ints;
}

void Print(int[] ints, string startIndex, string endIndex)
{
    int start=int.Parse(startIndex);
    int end=int.Parse(endIndex)+1;
    
    Console.WriteLine(string.Join(", ", ints[start..end]));
}

void Show(int[] ints, string index)
{
    Console.WriteLine(ints[int.Parse(index)]);
}
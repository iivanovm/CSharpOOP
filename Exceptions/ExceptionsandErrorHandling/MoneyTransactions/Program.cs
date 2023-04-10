
string[] accountRowData = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
Dictionary<int, double> accountWithBalance = new Dictionary<int, double>();
foreach (string accountRow in accountRowData)
{
    string[] accIn = accountRow.Split("-", StringSplitOptions.RemoveEmptyEntries);
    int accountId = int.Parse(accIn[0]);
    double balance = double.Parse(accIn[1]);
    if (!accountWithBalance.ContainsKey(accountId))
    {
        accountWithBalance[accountId] = balance;
    }
}
string cmd;
while ((cmd = Console.ReadLine()) != "End")
{
    string[] tokens = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string transType = tokens[0];
    int transID = int.Parse(tokens[1]);
    double transMoney = double.Parse(tokens[2]);
    try
    {
        switch (transType)
        {
            case "Deposit":
                Deposid(accountWithBalance, transID, transMoney);
                Console.WriteLine($"Account {transID} has new balance: {accountWithBalance[transID]:f2}");
                Console.WriteLine("Enter another command");
                break;
            case "Withdraw":
                Withdraw(accountWithBalance, transID, transMoney);
                Console.WriteLine($"Account {transID} has new balance: {accountWithBalance[transID]}:f2");
                Console.WriteLine("Enter another command");
                break;
            default:
                Console.WriteLine("Invalid command!");
                Console.WriteLine("Enter another command");
                break;
        }
        
    }
    catch (Exception ex) 
    { 
        Console.WriteLine(ex.Message);
        Console.WriteLine("Enter another command");
        continue;
    }
}

void Deposid(Dictionary<int, double> accountWithBalance, int id, double amount)
{
    if (!accountWithBalance.ContainsKey(id))
    {
        throw new ArgumentException("Invalid account!");
    }
    else if (accountWithBalance.ContainsKey(id))
    {
        accountWithBalance[id] += amount;
    }
}

void Withdraw(Dictionary<int, double> accountWithBalance, int id, double amount)
{
    if (!accountWithBalance.ContainsKey(id))
    {
        throw new ArgumentException("Invalid account!");
    }
    else if (accountWithBalance.ContainsKey(id))
    {
        if (accountWithBalance[id]-amount < 0)
        {
            throw new ArithmeticException("Insufficient balance!");
        }
        else
        {
            accountWithBalance[id] -= amount;
        }
    }
}
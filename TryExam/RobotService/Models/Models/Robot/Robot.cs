using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models.Models.Robot;

public abstract class Robot : IRobot
{

    private readonly List<int> interfaceStandards;
    private string model;
    private int batteryCapacity;
    private int batteryLevel;
    private int convertionCapacityIndex;


    protected Robot(string model, int batteryCapacity, int conversionCapacityIndex)
    {
        Model = model;
        BatteryCapacity = batteryCapacity;
        ConvertionCapacityIndex = conversionCapacityIndex;
        BatteryLevel = BatteryCapacity;
        interfaceStandards = new List<int>();
    }



    public string Model
    {
        get => model;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
            }
            model = value;
        }
    }
    public int BatteryCapacity
    {
        get => batteryCapacity;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
            }
            batteryCapacity = value;
        }
    }
    public int BatteryLevel
    {
        get => batteryLevel;
        protected set
        {
            batteryLevel = value;
        }
    }
    public int ConvertionCapacityIndex
    {
        get { return convertionCapacityIndex; }
        protected set { convertionCapacityIndex = value; }
    }
    public IReadOnlyCollection<int> InterfaceStandards => interfaceStandards;
    public void Eating(int minutes)
    {
        int currentcap = minutes * ConvertionCapacityIndex;
        if (BatteryLevel + currentcap < batteryCapacity)
        {
            BatteryLevel += currentcap;
        }
        else
        {
            BatteryLevel = batteryCapacity;
        }
    }
    public bool ExecuteService(int consumedEnergy)
    {
        if (BatteryLevel >= consumedEnergy)
        {
            BatteryLevel -= consumedEnergy;
            return true;
        }
        return false;
    }
    public void InstallSupplement(ISupplement supplement)
    {
        interfaceStandards.Add(supplement.InterfaceStandard);
        BatteryCapacity -= supplement.BatteryUsage;
        BatteryLevel -= supplement.BatteryUsage;
    }


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{GetType().Name} {Model}:")
            .AppendLine($"--Maximum battery capacity: {BatteryCapacity}")
            .AppendLine($"--Current battery level: {BatteryLevel}")
            .AppendLine($"--Supplements installed: {(interfaceStandards.Count == 0 ? "none" : string.Join(" ", interfaceStandards))}");
        return sb.ToString().Trim();
    }
}

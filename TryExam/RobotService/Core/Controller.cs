using RobotService.Core.Contracts;
using RobotService.Models.Contracts;
using RobotService.Models.Models.Robot;
using RobotService.Models.Models.Supplement;
using RobotService.Repositories;
using RobotService.Utilities;
using RobotService.Utilities.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Core;

public class Controller : IController
{
    private SupplementRepository supplements;
    private RobotRepository robots;
    private string[] validRobots = Utils.GetChildClassNames(typeof(Robot)).ToArray();
    private string[] validSupplements = Utils.GetChildClassNames(typeof(Supplement)).ToArray();

    public Controller()
    {
        supplements = new SupplementRepository();
        robots = new RobotRepository();
    }
    public string CreateRobot(string model, string typeName)
    {
        string robotName = $"RobotService.Models.Models.Robot.{typeName}";
        if (!validRobots.Contains(typeName))
        {
            return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
        }
        robots.AddNew((IRobot)Utils.CreateInstanceFromString(robotName, model));
        return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
    }
    public string CreateSupplement(string typeName)
    {
        if (!validSupplements.Contains(typeName))
        {
            return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
        }
        string stName = $"RobotService.Models.Models.Supplement.{typeName}";
        supplements.AddNew((ISupplement)Utils.CreateInstanceFromString(stName));
        return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
    }
    public string UpgradeRobot(string model, string supplementTypeName)
    {
        ISupplement supplement = supplements.FindByModel(supplementTypeName);
        List<IRobot> robotsToUpgrade = robots.FindByStandardnotCont(supplement.InterfaceStandard);
        if (robotsToUpgrade.Where(x => x.Model == model).Count() == 0)
        {
            return string.Format(OutputMessages.AllModelsUpgraded, model);
        }
        robotsToUpgrade.FirstOrDefault(r => r.Model == model).InstallSupplement(supplement);
        supplements.RemoveByName(supplementTypeName);
        return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);

    }
    public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
    {
        int counter = 0;
        if (robots.Models().Where(x => x.InterfaceStandards.Contains(intefaceStandard)).Count() == 0)
        {
            return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
        }
        int avaiblePower = robots.Models().Where(x => x.InterfaceStandards.Contains(intefaceStandard)).Sum(x => x.BatteryLevel);
        if (avaiblePower < totalPowerNeeded)
        {
            return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - avaiblePower);
        }
        else if (avaiblePower >= totalPowerNeeded)
        {
            while (totalPowerNeeded >= 0)
            {
                IRobot robot = robots.Models().OrderByDescending(r=>r.BatteryLevel).FirstOrDefault(r=>r.InterfaceStandards.Contains(intefaceStandard));
                if (robot.BatteryLevel >= totalPowerNeeded)
                {
                    counter++;
                    robot.ExecuteService(totalPowerNeeded);
                    break;
                }
                else if (robot.BatteryLevel < totalPowerNeeded)
                {
                    counter++;
                    totalPowerNeeded-= robot.BatteryLevel;
                    robot.ExecuteService(robot.BatteryLevel);
                    
                }
            }
        }

        return string.Format(OutputMessages.PerformedSuccessfully, serviceName, counter);
    }
    public string RobotRecovery(string model, int minutes)
    {
        int counter = 0;
        foreach (IRobot robot in robots.Models().Where(r =>r.Model==model&& r.BatteryLevel < (r.BatteryCapacity / 2)))
        {
            counter += 1;
            robot.Eating(minutes);
        }

        return string.Format(OutputMessages.RobotsFed, counter);
    }


    public string Report()
    {
        StringBuilder sb = new StringBuilder();
        List<IRobot> robs = robots.SortedMOdels().ToList();
        foreach (IRobot robot in robs)
        {
            sb.AppendLine(robot.ToString());
        }

        return sb.ToString().Trim();
    }

    public void End() => Environment.Exit(0);


}
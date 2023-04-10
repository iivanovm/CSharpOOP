using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Repositories;

public class RobotRepository : IRepository<IRobot>
{

    private readonly List<IRobot> robots;

    public RobotRepository()
    {
        robots = new List<IRobot>();
    }

    public void AddNew(IRobot model)=>robots.Add(model);

    public IRobot FindByStandard(int interfaceStandard)=>robots.FirstOrDefault(r=>r.InterfaceStandards.Contains(interfaceStandard));
    public List<IRobot> FindByStandardnotCont(int interfaceStandard) => robots.Where(r => !r.InterfaceStandards.Contains(interfaceStandard)).ToList();
    public List<IRobot> FindByStandardList(int interfaceStandard) => robots.Where(r => r.InterfaceStandards.Contains(interfaceStandard)).ToList();

    public List<IRobot> FindByBatteryLeve(int batteryLevel) => robots.Where(r => r.BatteryLevel < r.BatteryCapacity / 2).ToList();
    public IReadOnlyCollection<IRobot> Models()
    {
       return robots;
    }

    public bool RemoveByName(string typeName)=>robots.Remove(robots.FirstOrDefault(r=>r.Model==typeName));

    public IReadOnlyCollection<IRobot> SortedMOdels()
    {
        return robots.OrderByDescending(r=>r.BatteryLevel).ThenBy(r=>r.BatteryCapacity).ToList();
    }


}

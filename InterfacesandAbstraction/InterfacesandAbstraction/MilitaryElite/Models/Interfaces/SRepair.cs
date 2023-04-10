namespace MilitaryElite.Models.Interfaces;

public struct SRepair
{
    public SRepair(string partName, int hoursWorked)
    {
        PartName = partName;
        HoursWorked = hoursWorked;
    }

    string PartName { get; set; }
    int HoursWorked { get; set; }


    public override string ToString()
    {
        return $"Part Name: {PartName} Hours Worked: {HoursWorked}";

    }
}

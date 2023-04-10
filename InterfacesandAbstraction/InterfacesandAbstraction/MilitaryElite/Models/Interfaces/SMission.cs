namespace MilitaryElite;

using MilitaryElite.Enums;
using Models.Interfaces;


public struct SMission
{
    public SMission(string missionName, EMissionState missionState)
    {
        MissionName = missionName;
        MissionState = missionState;
    }

    public string MissionName { get; set; } 
    public EMissionState MissionState { get; set; }

    public override string ToString()
    {
        return $"Code Name: {MissionName} State: {MissionState}";
    }
}

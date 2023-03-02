namespace FootballTeam.Core;
using Model;

public static class Helper
{
    public static Player Read(string[] input)
    {
        Player currentPl = new Player(input[2], int.Parse(input[3]), int.Parse(input[4]), int.Parse(input[5]), int.Parse(input[6]), int.Parse(input[7]));
        return currentPl;
    }

    public static Team TeamRead(HashSet<Team> Team, string[] input)
    {
        Team currentTeam = Team.Where(x => x.Name == input[1]).FirstOrDefault();
        return currentTeam;
    }

    public static bool isExist(HashSet<Team> Team, string[] input)=>Team.Where(x=>x.Name== input[1]).Any();
}

namespace FootballTeam.Core;
using Model;
public class Core
{
    public static void Run()
    {
        string command;
        HashSet<Team> teams = new HashSet<Team>();
        while ((command = Console.ReadLine()) != "END")
        {
            string[] tokens = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
            if (teams.Count > 0)
            {
                var currentTeam = Helper.TeamRead(teams, tokens);
                bool isExistTeam = Helper.isExist(teams,tokens);
                if (tokens[0] == "Add")
                {
                    try
                    {
                        if (isExistTeam)
                        {
                            currentTeam.Add(Helper.Read(tokens));
                        }
                        else
                        {
                            Console.WriteLine($"Team {tokens[1]} does not exist.");
                        }
                    }
                    catch (Exception invalidFootbolist)
                    {
                        Console.WriteLine(invalidFootbolist.Message);
                    }
                }
                else if (tokens[0] == "Remove")
                {
                    currentTeam.Remove(tokens);
                }
                else if (tokens[0] == "Team")
                {
                    try
                    {
                        teams.Add(new Team(tokens[1]));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (tokens[0] == "Rating")
                {
                    if (isExistTeam)
                    {
                        Console.WriteLine(currentTeam);
                    }
                    else
                    {
                        Console.WriteLine($"Team {tokens[1]} does not exist.");
                    }
                }
                else
                {
                    continue;
                }
            }
            else if (teams.Count <= 0)
            {
                try
                {
                    teams.Add(new Team(tokens[1]));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

    }
}

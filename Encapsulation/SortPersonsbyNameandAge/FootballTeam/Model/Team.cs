namespace FootballTeam.Model;
public class Team
{
    private string name;
    private decimal rating;
    protected HashSet<Player> Teams;

    public Team(string name, decimal rating)
    {
        Name = name;
        Teams = new HashSet<Player>();
    }
    public Team()
    {
        Teams = new HashSet<Player>();
    }
    public Team(string name)
    {
        Name = name;
        Teams = new HashSet<Player>();
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }
    public decimal Rating
    {
        get
        {
            return rating;
        }
        private set
        {
            if (Teams.Count > 0)
            {
                rating = Teams.ToList().Sum(x => x.SkillLevel) / Teams.Count();
            }
            else
            {
                rating = 0;
            }

        }
    }

    public void Add(Player player)
    {
        Teams.Add(player);
    }
    public void Remove(string[] input)
    {
        if (Teams.ToList().Where(x => x.Name == input[2]).Any())
        {
            Teams.RemoveWhere(x => x.Name == input[2]);
        }
        else
        {
            Console.WriteLine($"Player {input[2]} is not in {input[1]} team.");
        }
    }
    public bool isExist(Player player) => Teams.Any(x => x.Equals(player));

    public override string ToString()
    {
        Rating = rating;
        return $"{Name} - {Rating}";
    }

}


namespace FootballTeam.Model;

public class Player : Stats
{
    private string name;
    private decimal skillLevel;

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        : base(endurance, sprint, dribble, passing, shooting)
    {
        Name = name;
        SkillLevel = skillLevel;
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
    public decimal SkillLevel
    {
        get
        {
            return skillLevel;
        }
        set
        {

            skillLevel = Math.Round(AvarageScore);
        }
    }

}

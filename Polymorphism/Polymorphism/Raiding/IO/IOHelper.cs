using Raiding.Models;

namespace Raiding.IO;

public class IOHelper
{
    public static BaseHero GetHero(string Type, string Name)
    {
        BaseHero hero = null;
        if (Type == "Druid")
        {
            hero = new Druid(Name);
        }
        else if (Type == "Paladin")
        {
            hero = new Paladin(Name);
        }
        else if (Type == "Rogue")
        {
            hero = new Rogue(Name);
        }
        else if (Type == "Warrior")
        {
            hero = new Warrior(Name);
        }
        return hero;
    }

    public static int GetHeroPower(List<BaseHero> heros)
    {
        int power = 0;
        heros.ForEach(x =>
        {
            if (x is Druid)
            {
                power += x.Power;
            }
            else if (x is Paladin)
            {
                power += x.Power;
            }
            else if (x is Rogue)
            {
                power += x.Power;
            }
            else if (x is Warrior)
            {
                power += x.Power;
            }

        });

        return power;
    }

    public bool IsValidHeroType(string Type)
    {
        return Type == "Druid"
              || Type == "Paladin"
              || Type == "Rogue"
              || Type == "Warrior";
    }
}

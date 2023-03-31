using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {

        public string Fight(ICollection<IHero> players)
        {
            List<Knight> knights = new List<Knight>();
            List<Barbarian> barbarians = new List<Barbarian>();
            foreach (IHero hero in players)
            {
                if (hero is Knight)
                {
                    knights.Add((Knight)hero);
                }
                else if (hero is Barbarian)
                {
                    barbarians.Add((Barbarian)hero);
                }
            }

            // Continue the battle until one team is completely dead
            while (knights.Count > 0 && barbarians.Count > 0)
            {
                // Knights attack first
                foreach (Knight knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        foreach (Barbarian barbarian in barbarians)
                        {
                            if (barbarian.IsAlive)
                            {
                                barbarian.TakeDamage(knight.Weapon.DoDamage());
                            }
                        }
                    }
                }

                // Barbarians attack next
                foreach (Barbarian barbarian in barbarians)
                {
                    if (barbarian.IsAlive)
                    {
                        foreach (Knight knight in knights)
                        {
                            if (knight.IsAlive)
                            {
                                knight.TakeDamage(barbarian.Weapon.DoDamage());
                            }
                        }
                    }
                }
            }

            // Determine the winning team and return the result
            if (knights.Count > 0)
            {
                int numDeadBarbarians = barbarians.Count(barbarian => !barbarian.IsAlive);
                return $"The knights took {numDeadBarbarians} casualties but won the battle.";
            }
            else
            {
                int numDeadKnights = knights.Count(knight => !knight.IsAlive);
                return $"The barbarians took {numDeadKnights} casualties but won the battle.";
            }
        }
    }
}

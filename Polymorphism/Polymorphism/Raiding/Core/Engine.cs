using Raiding.Core.interfaces;
using Raiding.IO;
using Raiding.IO.interfaces;

namespace Raiding.Core;

public class Engine : IOHelper, IEngine
{
    private IReader _reader;
    private IWriter _writer;

    List<BaseHero> heros;
    public Engine()
    {
        heros = new List<BaseHero>();
        _reader = new ConsoleReader();
        _writer = new ConsoleWriter();
    }

    public void Start(IReader reader, IWriter writer)
    {
        int Hero = int.Parse(reader.Read());
        int ValidHero = 0;
        while (ValidHero < Hero)
        {
            string currnerName = reader.Read();
            string Type = reader.Read();
            if (IsValidHeroType(Type))
            {
                ValidHero++;
                heros.Add(GetHero(Type, currnerName));
            }
            else
            {
                Console.WriteLine("Invalid hero!");
            }
        }
        int BossHealt = int.Parse(reader.Read());
        heros.ForEach(x => writer.WriteLine(x.CastAbility()));
        writer.WriteLine(GetHeroPower(heros) >= BossHealt ? "Victory!" : "Defeat...");
    }
}

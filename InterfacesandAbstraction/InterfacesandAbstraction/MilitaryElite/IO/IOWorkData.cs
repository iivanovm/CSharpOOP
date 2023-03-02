namespace MilitaryElite.IO;
using Enums;
using Models.Interfaces;
using Models;
using Core;
using IO.Interfaces;


public class IOWorkData
{
    private IWriter resultWrite=new ConsoleWriter();    
    
    protected List<SRepair> ToRepSet(string[] rep,int StartPosition)
    {
        List<SRepair> parts = new List<SRepair>();
        string[] test = rep[StartPosition..rep.Length];
        for (int i = 0; i < test.Length - 1; i += 2)
        {
            parts.Add(new SRepair(test[i], int.Parse(test[i + 1])));
        }

        return parts;
    }

    protected List<SMission> ToMiss(string[] rep, int StartPosition)
    {
        List<SMission> miss = new List<SMission>();

        string[] test = rep[StartPosition..rep.Length];
        for (int i = 0; i < test.Length - 1; i += 2)
        {
            bool isParsed = Enum.TryParse(test[i + 1], false, out EMissionState result);
            if (isParsed)
            {
                miss.Add(new SMission(test[i], result));
            }
        }

        return miss;
    }

    protected ICollection<IPrivate> ToPrS(string[] rep, ICollection<ISoldier> privateS)
    {
       int[] tokens= rep.Skip(5).Select(int.Parse).ToArray();
       ICollection<IPrivate> privates= new HashSet<IPrivate>();
        foreach(int pid in tokens)
        {
            IPrivate currentP=(IPrivate)privateS.FirstOrDefault(s=>s.Id==pid);

            privates.Add(currentP);
        }

        return privates;
    }

    protected void PrintAllSoldier(ICollection<ISoldier> solders)
    {
        foreach (var sol in solders)
        {
            resultWrite.WriteLine(sol.ToString());
        }
    }    
}

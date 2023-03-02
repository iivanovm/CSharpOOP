namespace MilitaryElite.Core;
using IO;
using IO.Interfaces;
using Core.Interfaces;
using Models.Interfaces;
using Models;
using MilitaryElite.Enums;
using System.Collections.Generic;

public class Engine : IOWorkData, IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly ICollection<ISoldier> ASoldiers;


    public Engine()
    {
        ASoldiers = new HashSet<ISoldier>();
    }
    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
        ASoldiers = new HashSet<ISoldier>();
    }



    public void Start()
    {
        string command = string.Empty;
        while ((command = reader.ReadLine()) != "End")
        {
            string[] tokens = command.Split(" ");
            string soldierType = tokens[0];
            int id = int.Parse(tokens[1]);
            string firstName = tokens[2];
            string lastName = tokens[3];
            decimal salary = decimal.Parse(tokens[4]);
            ISoldier soldier;
            switch (soldierType)
            {
                case "Private":
                    soldier = new Private(id, firstName, lastName, salary);
                    ASoldiers.Add(soldier);
                    break;


                case "Spy":
                    int SpyNumber = int.Parse(tokens[4]);
                    soldier = new Spy(id, firstName, lastName, SpyNumber);
                    ASoldiers.Add(soldier);
                    break;


                case "LieutenantGeneral":
                    ICollection<IPrivate> privates = ToPrS(tokens, ASoldiers);
                    soldier = new LeutenantGeneral(id, firstName, lastName, salary, privates);
                    ASoldiers.Add(soldier);
                    break;


                case "Engineer":
                    string corpsText = tokens[5];
                    int repSetStartPosition = 6;
                    bool isCorp = Enum.TryParse<ECorps>(corpsText, true, out ECorps corps);
                    if (!isCorp)
                    {
                        continue;
                    }
                    ICollection<SRepair> currentRepSet = ToRepSet(tokens,repSetStartPosition);
                    soldier = new Engineer(id, firstName, lastName, salary, corps, currentRepSet);
                    ASoldiers.Add(soldier);
                    break;


                case "Commando":
                    string corpsTextC = tokens[5];
                    int missionStartPosition = 6;
                    bool isCorpC = Enum.TryParse<ECorps>(corpsTextC, true, out ECorps corpsc);
                    if (!isCorpC)
                    {
                        continue;
                    }
                    ICollection<SMission> currentMission = ToMiss(tokens,missionStartPosition);
                    soldier = new Commando(id, firstName, lastName, salary, corpsc, currentMission);
                    ASoldiers.Add(soldier);
                    break;
                default: continue;
            }
        }
        PrintAllSoldier(ASoldiers);
    }
}

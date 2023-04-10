﻿namespace MilitaryElite.Models;

using Interfaces;

public abstract class Soldier : ISoldier
{
    protected Soldier(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    protected Soldier() 
    { 

    }

    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName {get;set; }

    public override string ToString()
    {
        return $"Name: {FirstName} {LastName} Id: {Id}";
    }
}

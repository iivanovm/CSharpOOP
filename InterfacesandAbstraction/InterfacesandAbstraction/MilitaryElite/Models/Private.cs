﻿using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models;

public class Private : Soldier, IPrivate
{
    public Private(int id, string firstName, string lastName,decimal salary) 
        : base(id, firstName, lastName)
    {
        Salary = salary;
    }
    public Private()
    {
            
    }

    public decimal Salary { get; set; }

    public override string ToString()
    {
        return base.ToString()+ $" Salary: {Salary:f2}";
    }


}

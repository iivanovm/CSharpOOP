﻿using System;
using System.Collections.Generic;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models;

public class University : IUniversity
{
    private int id;
    private string name;
    private string category;
    private int capacity;
    private List<int> requiredSubjects;

    public University(int id, string name, string category, int capacity, List<int> requiredSubjects)
    {
        Id = id;
        Name = name;
        Category = category;
        Capacity = capacity;
        this.requiredSubjects = requiredSubjects;
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }


    public string Name
    {
        get =>name; 
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NameNullOrWhitespace));
            }
            name = value;
        }
    }

    public string Category
    {
        get=> category;
        set
        {
            if (value != "Technical" && value != "Economical" && value != "Humanity")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CategoryNotAllowed,value));
            }
            category = value;
        }
    }

    public int Capacity
    {
        get => capacity;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CapacityNegative));
            }
            capacity = value;
        }
    }


    public IReadOnlyCollection<int> RequiredSubjects => requiredSubjects;
}

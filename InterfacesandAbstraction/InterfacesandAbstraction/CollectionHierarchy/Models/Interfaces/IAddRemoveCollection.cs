namespace CollectionHierarchy.Models.Interfaces;

using Models.Interfaces;
using Models;
using System.Collections.Generic;
using System.Collections;

public interface IAddRemoveCollection :IAddCollection
{
    string Remove();
}

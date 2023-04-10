namespace CollectionHierarchy.Engine;

using CollectionHierarchy.Engine.interfaces;
using CollectionHierarchy.IO;
using CollectionHierarchy.IO.interfaces;
using CollectionHierarchy.Models;
using CollectionHierarchy.Models.Interfaces;

public class Engine : Print, IEngines
{

    public void Run(IReader reader, IWriter writer)
    {
        Dictionary<string, List<int>> addedIndexes = new()
            {
                { "AddCollection", new List<int>() },
                { "AddRemoveCollection", new List<int>() },
                { "MyList", new List<int>() }
            };

        Dictionary<string, List<string>> removedItems = new()
            {
                { "AddCollection", new List<string>() },
                { "AddRemoveCollection", new List<string>() },
                { "MyList", new List<string>() }
            };

        IAddCollection addCollection = new AddCollection();
        IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
        IMyList myList = new MyList();

        string[] items = reader.Read().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        foreach (var item in items)
        {
            addedIndexes["AddCollection"].Add(addCollection.Add(item));

            addedIndexes["AddRemoveCollection"].Add(addRemoveCollection.Add(item));

            addedIndexes["MyList"].Add(myList.Add(item));
        }

        int removeCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < removeCount; i++)
        {
            removedItems["AddRemoveCollection"].Add(addRemoveCollection.Remove());
            removedItems["MyList"].Add(myList.Remove());
        }

        PrintResult(addedIndexes, removedItems);
    }
}

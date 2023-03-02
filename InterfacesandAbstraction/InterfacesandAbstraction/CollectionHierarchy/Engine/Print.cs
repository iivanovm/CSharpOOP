namespace CollectionHierarchy;

using IO;
using IO.interfaces;



public class Print
{
    IWriter writer=new ConsoleWriter();

    public void PrintResult(Dictionary<string, List<int>> addedIndexes, Dictionary<string, List<string>> removedItems)
    {
       writer.WriteLine(string.Join(" ", addedIndexes["AddCollection"]));
        writer.WriteLine(string.Join(" ", addedIndexes["AddRemoveCollection"]));
        writer.WriteLine(string.Join(" ", addedIndexes["MyList"]));

        writer.WriteLine(string.Join(" ", removedItems["AddRemoveCollection"]));
        writer.WriteLine(string.Join(" ", removedItems["MyList"]));
    }
}

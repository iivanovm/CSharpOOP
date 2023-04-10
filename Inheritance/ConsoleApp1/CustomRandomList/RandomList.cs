namespace CustomRandomList;

public class RandomList : List<string>
{
    private Random random;

    public RandomList()
    {
        random = new Random();
    }
    public string RandomString()
    {
        int index = random.Next(0, this.Count + 1);
        string removedElements = this[index];
        this.RemoveAt(index);
        return removedElements;
    }
}

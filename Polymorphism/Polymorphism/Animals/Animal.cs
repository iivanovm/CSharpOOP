public  class Animal
{
    private string name;
    private string favouriteFood;

    public Animal(string name, string favouriteFood)
    {
        Name = name;
        FavouriteFood = favouriteFood;
    }

    public string Name { get; protected set; }
    public string FavouriteFood { get; protected set; }


    public virtual string ExplainSelf()
    {
        return $"I am {Name} and my fovourite food is {this.FavouriteFood}";
    }
}
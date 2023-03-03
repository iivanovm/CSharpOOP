namespace WildFarm.IO;
using WildFarm.Enums;


public  class EatBuilder
{
    protected string Name { get;set; }
    protected int Quantity { get; set; }


    public EatBuilder(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }

    bool isValid;

   
   


    public static void Check(string name) 
    {

    }


}

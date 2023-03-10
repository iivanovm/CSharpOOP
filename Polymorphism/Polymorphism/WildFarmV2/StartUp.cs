using WildFarmV2.Init;
using WildFarmV2.Init.@interface;



public class StartUp
{
    public static void Main()
    {
        IInitialize init = new Initiazlize();
        init.Setup();
    }
}
using WildFarm.Init;


public class StartUp
{
    public static void Main()
    {
        IInitialize init= new Initiazlize();
        init.Setup();
    }
}
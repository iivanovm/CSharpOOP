﻿namespace Stealer;

public class StartUp
{
    public static void Main()
    {
        Spy spy = new Spy();
        string result = spy.CollectGettersAndSetter("Stealer.Hacker");
        Console.WriteLine(result);
    }
}

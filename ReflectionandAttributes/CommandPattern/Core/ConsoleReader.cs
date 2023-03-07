namespace CommandPattern.Core
{
    using System;
    using CommandPattern.Core.Contracts;
    using Contracts;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
            => Console.ReadLine();
    }
}

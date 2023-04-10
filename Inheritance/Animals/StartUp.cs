using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> Animals = new List<Animal>();
            string command;
            while ((command = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    string[] tokens = Console.ReadLine().Split(" ");
                    if (command == "Dog")
                    {
                        Dog dog = new Dog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        Animals.Add(dog);
                    }
                    else if (command == "Cat")
                    {
                        Cat cat = new Cat(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        Animals.Add(cat);
                    }
                    else if (command == "Frog")
                    {
                        Frog frog = new Frog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        Animals.Add(frog);
                    }
                    else if (command == "Kittens")
                    {
                        Kitten kitten = new Kitten(tokens[0], int.Parse(tokens[1]));
                        Animals.Add(kitten);
                    }
                    else if (command == "Tomcat")
                    {
                        Tomcat tomcats = new Tomcat(tokens[0], int.Parse(tokens[1]));
                        Animals.Add(tomcats);
                    }
                }
                catch(Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }

            foreach (var item in Animals)
            {
                Console.WriteLine(item);
            }
        }
    }
}

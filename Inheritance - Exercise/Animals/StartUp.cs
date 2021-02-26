using System;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Beast!")
                {
                    break;
                }

                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string gender = tokens[2];

                if (age < 0 || String.IsNullOrEmpty(name) || string.IsNullOrEmpty(gender))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (line == "Cat")
                {
                    Cat current = new Cat(name, age, gender);
                    Console.WriteLine(current);
                    Console.WriteLine(current.ProduceSound());
                }
                else if (line == "Dog")
                {
                    Dog current = new Dog(name, age, gender);
                    Console.WriteLine(current);
                    Console.WriteLine(current.ProduceSound());
                }
                else if (line == "Frog")
                {
                    Frog current = new Frog(name, age, gender);
                    Console.WriteLine(current);
                    Console.WriteLine(current.ProduceSound());
                }
                else if (line == "Kitten")
                {
                    Kitten current = new Kitten(name, age);
                    Console.WriteLine(current);
                    Console.WriteLine(current.ProduceSound());
                }
                else if (line == "Tomcat")
                {
                    Tomcat current = new Tomcat(name, age);
                    Console.WriteLine(current);
                    Console.WriteLine(current.ProduceSound());
                }
            }
        }
    }
}

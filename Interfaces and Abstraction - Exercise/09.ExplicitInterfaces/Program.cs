using System;
using System.Collections.Generic;

namespace _09.ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Citizen> allCitizens = new List<Citizen>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line=="End")
                {
                    break;
                }
                string[] tokens = line.Split();

                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                Citizen citizen = new Citizen(name, country, age);
                allCitizens.Add(citizen);
            }
            foreach (var item in allCitizens)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.GetName());
            }
        }
    }
}

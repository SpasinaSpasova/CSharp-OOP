using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthdays = new List<IBirthable>();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }
                string[] tokens = line.Split();
                if (nameof(Citizen) == tokens[0])
                {
                    birthdays.Add(new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]));
                }
                else if (nameof(Pet) == tokens[0])
                {
                    birthdays.Add(new Pet(tokens[1], tokens[2]));

                }
            }
            string checker = Console.ReadLine();
            foreach (var item in birthdays.Where(t=>t.Birthdate.EndsWith(checker)))
            {
                Console.WriteLine(item.Birthdate);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> identifiable = new List<IIdentifiable>();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }
                string[] tokens = line.Split();

                if (tokens.Length == 3)
                {
                    identifiable.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]));
                }
                else if (tokens.Length == 2)
                {
                    identifiable.Add(new Robot(tokens[0], tokens[1]));
                }
            }

            string checker = Console.ReadLine();

            foreach (var item in identifiable.Where(x => x.Id.EndsWith(checker)))
            {
                Console.WriteLine(item.Id);
            }
        }
    }
}

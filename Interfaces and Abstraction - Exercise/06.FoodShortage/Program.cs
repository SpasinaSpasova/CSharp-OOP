using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FoodShortage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Citizen> info = new List<Citizen> ();
            List<Rebel> info2 = new List<Rebel> ();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split();
                if (line.Length == 3)
                {
                    
                        info2.Add(new Rebel(line[0], int.Parse(line[1]), line[2]));
                    
                }
                else
                {
                       info.Add(new Citizen(line[0], int.Parse(line[1]), line[2], line[3]));
                    
                }
            }

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }
                if (info.FirstOrDefault(x=>x.Name==line)!=null)
                {
                    var citizen = info.FirstOrDefault(x => x.Name == line);
                    citizen.BuyFood();
                }
                if (info2.FirstOrDefault(x => x.Name == line) != null)
                {
                    var rebel = info2.FirstOrDefault(x => x.Name == line);
                    rebel.BuyFood();
                }
            }
            Console.WriteLine(info.Sum(p=>p.Food)+info2.Sum(p=>p.Food));

        }
    }
}

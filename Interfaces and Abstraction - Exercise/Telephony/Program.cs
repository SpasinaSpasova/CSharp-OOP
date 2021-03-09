using System;
using System.Linq;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split().ToArray();
            string[] urls = Console.ReadLine().Split().ToArray();

            foreach (var item in numbers)
            {
                if (item.Any(char.IsLetter))
                {
                    Console.WriteLine("Invalid number!");
                    
                }
                else if (item.Length==10)
                {
                    SmartPhone phone = new SmartPhone();
                    Console.WriteLine(phone.Call(item));
                }
                else if (item.Length==7)
                {
                    StationaryPhone phone = new StationaryPhone();
                    Console.WriteLine(phone.Call(item));
                }
            }
            foreach (var item in urls)
            {
                if (item.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid URL!");

                }
                else
                {
                    SmartPhone phone = new SmartPhone();
                    Console.WriteLine(phone.Browse(item));

                }
            }

        }
    }
}

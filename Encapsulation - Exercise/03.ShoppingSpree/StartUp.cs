using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                persons = Console.ReadLine().Split(';').ToList()
                       .Select(t => t.Split('='))
                       .Select(p => new Person(p[0], decimal.Parse(p[1])))
                       .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            try
            {
                products = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList()
                       .Select(t => t.Split('='))
                       .Select(p => new Product(p[0], decimal.Parse(p[1])))
                       .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }
                string[] tokens = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                Person person = persons.First(p => p.Name == tokens[0]);
                Product product = products.First(p => p.Name == tokens[1]);

                person.PersonBuyingProduct(product);
            }
            foreach (var item in persons)
            {
                Console.WriteLine(item);
            }
        }
    }
}

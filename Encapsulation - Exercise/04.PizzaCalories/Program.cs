using System;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string pizzaName = Console.ReadLine().Split()[1];

            string[] doughInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string flour = doughInfo[1];
            string bakingTech = doughInfo[2];
            double weight = double.Parse(doughInfo[3]);

            try
            {
                Dough dough = new Dough(flour, bakingTech, weight);

                Pizza pizza = new Pizza(pizzaName, dough);


                while (true)
                {
                    string line = Console.ReadLine();
                    if (line == "END")
                    {
                        break;
                    }
                    string[] tokens = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string toppingName = tokens[1];
                    double toppingWeight = double.Parse(tokens[2]);

                    Topping currTopping = new Topping(toppingName, toppingWeight);
                    pizza.AddTopping(currTopping);
                }
                Console.WriteLine($"{pizza.Name} - {pizza.GetCalories():f2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}

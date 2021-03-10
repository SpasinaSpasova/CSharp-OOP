using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> allAnimals = new List<Animal>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }
                string[] line = input.Split();


                //creating animals and adding to list
                Animal animal = CreateAnimal(line);
                allAnimals.Add(animal);

                string[] foodInfo = Console.ReadLine().Split();
                Food food = CreateFood(foodInfo);

                animal.ProduceSound();

                try
                {
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            foreach (var animal in allAnimals)
            {
                Console.WriteLine(animal);
            }

        }

        private static Food CreateFood(string[] foodInfo)
        {
            Food food = null;

            string type = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);

            if (nameof(Vegetable) == type)
            {
                food = new Vegetable(quantity);
            }
            else if (nameof(Meat) == type)
            {
                food = new Meat(quantity);
            }
            else if (nameof(Seeds) == type)
            {
                food = new Seeds(quantity);
            }
            else if (nameof(Fruit) == type)
            {
                food = new Fruit(quantity);
            }
            return food;
        }

        private static Animal CreateAnimal(string[] info)
        {
            Animal animal = null;
            string type = info[0];

            if (type == nameof(Owl))
            {
                animal = new Owl(info[1], double.Parse(info[2]), double.Parse(info[3]));
            }
            else if (type == nameof(Hen))
            {
                animal = new Hen(info[1], double.Parse(info[2]), double.Parse(info[3]));
            }
            else if (type == nameof(Mouse))
            {
                animal = new Mouse(info[1], double.Parse(info[2]), info[3]);
            }
            else if (type == nameof(Dog))
            {
                animal = new Dog(info[1], double.Parse(info[2]), info[3]);
            }
            else if (type == nameof(Cat))
            {
                animal = new Cat(info[1], double.Parse(info[2]), info[3], info[4]);
            }
            else if (type == nameof(Tiger))
            {
                animal = new Tiger(info[1], double.Parse(info[2]), info[3], info[4]);
            }
            return animal;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private const int MinRange = 1;
        private const int MaxRange = 50;

        private string name;
        private double weight;
        private HashSet<string> toppings=new HashSet<string>(){ "meat","cheese","veggies" ,"sauce"};

        public Topping(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (!toppings.Contains(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.name = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < MinRange || value > MaxRange)
                {
                    throw new ArgumentException($"{this.Name} weight should be in the range [{MinRange}..{MaxRange}].");
                }
                this.weight = value;
            }
        }

        public double GetCalories()
        {
            return this.Weight * 2 * GetToppingType();
        }


        private double GetToppingType()
        {
            if (this.Name.ToLower() == "meat")
            {
                return 1.2;
            }
            else if (this.Name.ToLower() == "veggies")
            {
                return 0.8;
            }
            else if (this.Name.ToLower() == "cheese")
            {
                return 1.1;
            }
            return 0.9;

        }
    }
}

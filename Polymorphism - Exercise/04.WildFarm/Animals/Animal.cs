using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public abstract class Animal
    {
        protected Animal(string name, double weight, HashSet<string> allowedFoods, double weightModifier)
        {
            Name = name;
            Weight = weight;

            AllowedFoods = allowedFoods;
            WeightModifier = weightModifier;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
        private HashSet<string> AllowedFoods { get; set; }
        private double WeightModifier { get; set; }
        public abstract void ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }

        public void Eat(Food food)
        {
            if (!this.AllowedFoods.Contains(food.GetType().Name))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            this.FoodEaten += food.Quantity;
            this.Weight += WeightModifier * food.Quantity;
        }
    }
}

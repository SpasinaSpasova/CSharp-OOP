using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Feline : Mammal
    {
        public Feline(string name, double weight, HashSet<string> allowedFoods, double weightModifier, string livingRegion, string breed) : base(name, weight, allowedFoods, weightModifier, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; set; }

        public override void ProduceSound()
        {
           
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}

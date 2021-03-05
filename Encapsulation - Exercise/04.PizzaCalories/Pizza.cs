using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories
{ 

    public class Pizza
    {
        private const int MinValue = 1;
        private const int MaxValue = 15;

        private const int MinTopping = 0;
        private const int MaxTopping = 10;

        private string name;
        private Dough dough;
        private List<Topping> toppings;
        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < MinValue 
                    || value.Length > MaxValue)
                {
                    throw new ArgumentException($"Pizza name should be between {MinValue} and {MaxValue} symbols.");
                }
                this.name = value;
            }
        }

        public Dough Dough { get; set; }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count==10)
            {
                throw new InvalidOperationException($"Number of toppings should be in range [{MinTopping}..{MaxTopping}].");
            }
            toppings.Add(topping);
        }
         public double GetCalories()
        {
            double sum = this.toppings.Sum(s => s.GetCalories());
            return this.Dough.GetCalories() + sum;
        }
      
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
       

        private const int MinWeight = 1;
        private const int MaxWeight = 200;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        private HashSet<string> flourTypeHashSet = new HashSet<string>() { "white", "wholegrain" };

        private HashSet<string> bakingTechnicsHashSet = new HashSet<string>() { "homemade", "chewy","crispy"};
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (!flourTypeHashSet.Contains(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (!bakingTechnicsHashSet.Contains(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }
        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
                }
                this.weight = value;
            }
        }
        public double GetCalories()
        {
            return this.Weight*2 * bakingTechniqueType() * GetFlourType();
        }

        private double bakingTechniqueType()
        {
            if (this.BakingTechnique.ToLower() == "crispy")
            {
                return 0.9;
            }
            else if (this.BakingTechnique.ToLower() == "chewy")
            {
                return 1.1;
            }
            return 1;
        }
        private double GetFlourType()
        {
            if (this.FlourType.ToLower() == "white")
            {
                return 1.5;
            }
            return 1;

        }
    }
}

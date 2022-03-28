namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    public class Dough
    {
        private const double BaseDoughCalories = 2;
        private Dictionary<string, double> validFlourType;
        private Dictionary<string, double> validBakingTechnique;
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.validFlourType = new Dictionary<string, double>();
            this.validBakingTechnique = new Dictionary<string, double>();
            this.SeedFlourType();
            this.SeedBakingTechnique();
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (!validFlourType.ContainsKey(value.ToLower()))
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
                if (!validBakingTechnique.ContainsKey(value.ToLower()))
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
                if(value<1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }


        public double CalculateCalories()
        {
            return BaseDoughCalories*this.Weight*this.validFlourType[this.FlourType.ToLower()]*this.validBakingTechnique[this.BakingTechnique.ToLower()];
        }


        private void SeedFlourType()
        {
            validFlourType.Add("white", 1.5);
            validFlourType.Add("wholegrain", 1.0);
        }

        private void SeedBakingTechnique()
        {
            validBakingTechnique.Add("crispy", 0.9);
            validBakingTechnique.Add("chewy", 1.1);
            validBakingTechnique.Add("homemade", 1.0);
        }
    }
}

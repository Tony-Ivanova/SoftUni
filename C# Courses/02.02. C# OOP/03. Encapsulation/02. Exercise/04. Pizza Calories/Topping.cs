namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    public class Topping
    {
        private const double BaseCaloriesForTopping = 2;
        private string type;
        private double weight;
        private Dictionary<string, double> validToppings;

        public Topping(string type, double weight)
        {
            this.validToppings = new Dictionary<string, double>();
            this.SeedValidToppings();
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;
            private set
            {
                if (!validToppings.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.type} weight should be in the range[1..50].");
                }
                this.weight = value;
            }
        }

        public double CaloriesForToppings()
        {
            return BaseCaloriesForTopping * this.Weight * this.validToppings[this.Type.ToLower()];
        }

        private void SeedValidToppings()
        {
            validToppings.Add("meat", 1.2);
            validToppings.Add("veggies", 0.8);
            validToppings.Add("cheese", 1.1);
            validToppings.Add("sauce", 0.9);
        }
    }
}

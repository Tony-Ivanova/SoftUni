namespace _04._Wild_Farm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using _04._Wild_Farm.Models.Foods;

    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract string ProduceSound();

        public abstract void Eat(Food food);

        protected void BaseEat(Food food, List<string> eatableFood, double increase)
        {
            string typeFood = food.GetType().Name;

            if (!eatableFood.Contains(typeFood))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {typeFood}!");
            }

            this.Weight += food.Quantity * increase;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}

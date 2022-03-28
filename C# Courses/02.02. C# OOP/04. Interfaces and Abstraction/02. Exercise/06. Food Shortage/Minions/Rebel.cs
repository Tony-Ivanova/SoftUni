﻿namespace FoodShortage.Minions
{
    using FoodShortage.Interfaces;
    public class Rebel : IBuyer
    {
        private const int food = 0;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = food;
        }

        public string Group { get; set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public int Food { get; private set; }

        public int BuyFood()
        {
           return this.Food += 5;
        }
    }
}

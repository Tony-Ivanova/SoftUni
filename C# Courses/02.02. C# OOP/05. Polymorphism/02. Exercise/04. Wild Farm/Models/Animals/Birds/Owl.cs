using System.Collections.Generic;
using _04._Wild_Farm.Models.Foods;

namespace _04._Wild_Farm.Models.Animals
{
    public class Owl : Bird
    {
        private const double Increase = 0.25;

        public Owl(string name, double weight, double wingSize)
           : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>() { nameof(Meat) }, Increase);
        }

        public override string ProduceSound()
        {
            return $"Hoot Hoot";
        }
    }
}

namespace _04._Wild_Farm.Models.Animals
{
    using System.Collections.Generic;
    using _04._Wild_Farm.Models.Foods;

    public class Hen : Bird
    {
        private const double Increase = 0.35;

        public Hen(string name, double weight, double wingSize)
           : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>() { nameof(Meat), nameof(Fruit), nameof(Seeds), nameof(Vegetable) }, Increase);
        }

        public override string ProduceSound()
        {
            return $"Cluck";
        }
    }
}

namespace _04._Wild_Farm.Models.Animals
{
    using System.Collections.Generic;
    using _04._Wild_Farm.Models.Foods;

    public class Mouse : Mammal
    {
        private const double Increase = 0.10;

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>() { nameof(Vegetable), nameof(Fruit) }, Increase);
        }

        public override string ProduceSound()
        {
            return $"Squeak";
        }
    }
}

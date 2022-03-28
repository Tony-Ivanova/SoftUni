namespace _04._Wild_Farm.Models.Animals
{
    using System.Collections.Generic;
    using _04._Wild_Farm.Models.Foods;

    public class Cat : Feline
    {
        private const double Increase = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>() { nameof(Meat), nameof(Vegetable) }, Increase);
        }

        public override string ProduceSound()
        {
            return $"Meow";
        }
    }
}

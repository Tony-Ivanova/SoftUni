namespace _04._Wild_Farm.Models.Animals
{
    using System.Collections.Generic;
    using _04._Wild_Farm.Models.Foods;

    public class Dog : Mammal
    {
        private const double Increase = 0.40;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>() { nameof(Meat) }, Increase);
        }

        public override string ProduceSound()
        {
            return $"Woof!";
        }
    }
}

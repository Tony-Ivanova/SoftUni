namespace _04._Wild_Farm.Models.Animals
{
    using System.Collections.Generic;
    using _04._Wild_Farm.Models.Foods;

    public class Tiger : Feline
    {
        private const double Increase = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>() { nameof(Meat) }, Increase);
        }

        public override string ProduceSound()
        {
            return $"ROAR!!!";
        }
    }
}

namespace Restaurant.Foods.Desserts
{
    public class Cake: Dessert
    {
        private const decimal DefaultPriceForCake = 5m;

        private const double DefaultGramsForCake = 250;

        private const double DefaultCaloriesForCake = 1000;


        public Cake(string name)
            : base(name, DefaultPriceForCake, DefaultGramsForCake, DefaultCaloriesForCake)
        {
        }
        
    }
}

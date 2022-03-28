namespace _01._Vehicles
{
    public class Car : Vehicle
    {
        private const double airConditionConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption + airConditionConsumption)
        {
        }
    }
}
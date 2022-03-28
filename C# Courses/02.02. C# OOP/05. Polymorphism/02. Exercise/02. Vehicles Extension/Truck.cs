namespace _02._Vehicles_Extension
{
    public class Truck : Vehicle
    {
        private const double airConditionConsumption = 1.6;
        private const double wastedFuel = 0.05;

        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption + airConditionConsumption, tankCapacity)
        {
        }

        public override void Refuel(double amount)
        {
            base.Refuel(amount);
            this.FuelQuantity -= amount * wastedFuel;
        }
    }
}

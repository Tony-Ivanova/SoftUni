namespace _01._Vehicles
{
    public class Truck : Vehicle
    {
        private const double airConditionConsumption = 1.6;
        private const double wastedFuel = 0.05;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption + airConditionConsumption)
        {
        }

        public override void Refuel(double amount)
        {
            this.FuelQuantity -= amount * wastedFuel;
            base.Refuel(amount);
        }
    }
}

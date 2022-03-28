namespace _02._Vehicles_Extension
{
    public class Bus : Vehicle
    {
        private const double airConditionConsunption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption + airConditionConsunption, tankCapacity)
        {
        }

        public string DriveEmpty(double distance)
        {
            this.FuelConsumption -= airConditionConsunption;
            return base.Drive(distance);
        }
    }
}

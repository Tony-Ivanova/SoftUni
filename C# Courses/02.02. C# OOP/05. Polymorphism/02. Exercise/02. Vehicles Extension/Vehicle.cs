namespace _02._Vehicles_Extension
{
    using System;
    public abstract class Vehicle
    {
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public int TankCapacity { get; private set; }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption { get; protected set; }

        public virtual void Refuel(double amount)
        {

            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            double totalFuelAmount = this.fuelQuantity + amount;

            if (totalFuelAmount > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }
            this.fuelQuantity += amount;
        }

        public string Drive(double distance)
        {
            string vehicleName = this.GetType().Name;
            double neededFuel = this.FuelConsumption * distance;

            if (this.fuelQuantity >= neededFuel)
            {
                this.fuelQuantity -= neededFuel;

                return $"{vehicleName} travelled {distance} km";
            }
            else
            {
                return $"{vehicleName} needs refueling";
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}

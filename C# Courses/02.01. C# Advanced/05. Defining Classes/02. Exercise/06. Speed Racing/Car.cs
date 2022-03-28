namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car
    {
        public Car(string model, decimal fuelAmount, decimal fuelConsumptionFor1km)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumptionFor1km;
        }

        public string Model { get; set; }

        public decimal FuelConsumption { get; set; }

        public decimal FuelAmount { get; set; }

        public decimal TraveledDistance { get; set; }

        public void Drive(decimal distance)
        {
            if (this.FuelAmount < distance * this.FuelConsumption)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.FuelAmount -= distance * this.FuelConsumption;
                this.TraveledDistance += distance;
            }
        }
    }
}

namespace CarManufacturer
{
    using System;
    using System.Text;

    public class Car
    {
        public string make;

        public string model;

        public int year;

        public double fuelQuantity;

        public double fuelConsumption;

        public Car(
            string make,
            string model,
            int year,
            double fuelQuantity,
            double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(
            string make,
            string model,
            int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public void Drive(double distance)
        {
            double consumedFuel = distance * this.fuelConsumption;
            if (this.fuelQuantity - consumedFuel >= 0)
            {
                this.fuelQuantity -= consumedFuel;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Make: {this.Make}");
            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"Year: {this.Year}");
            result.Append($"Fuel: {this.FuelQuantity:F2}L");
            return result.ToString();
        }
    }
}

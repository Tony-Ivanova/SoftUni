namespace _03._Speed_Racing
{
    using System;
    using System.Collections.Generic;

    public class Car
    {        
        public Car(string model, decimal fuelAmount, decimal fuelConsumptionFor1km)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionFor1km = fuelConsumptionFor1km;
        }

        public string Model { get; set; }

        public decimal FuelConsumptionFor1km { get; set; }
    

        public decimal FuelAmount { get; set; }

        public decimal TraveledDistance { get; set; }

        public void Drive(decimal distance)
        {
            if (this.FuelAmount < distance * this.FuelConsumptionFor1km)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.FuelAmount -= distance * this.FuelConsumptionFor1km;
                this.TraveledDistance += distance;
            }
        }
    }

    public class StartUp
    {
        public static void Main()
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                var currentCar = Console.ReadLine()
                    .Split(new char[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries);

                string model = currentCar[0];
                decimal fuelAmount = decimal.Parse(currentCar[1]);
                decimal fuelConsumptionPer1Km = decimal.Parse(currentCar[2]);

                var car = new Car(model, fuelAmount, fuelConsumptionPer1Km);
                cars.Add(car);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                var tokens = input.Split(new char[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[1];
                decimal distanceTraveled = decimal.Parse(tokens[2]);

                cars.Find(x => x.Model == model).Drive(distanceTraveled);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }
        }
    }
}

namespace _08._Vehicle_Catalogue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }
    }

    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double HorsePower { get; set; }
    }

    public class Catalog
    {
        public ICollection<Car> Cars { get; set; }
        public ICollection<Truck> Trucks { get; set; }
    }

    public class StartUp
    {
        public static void Main()
        {
            string line = Console.ReadLine();
                List<Car> cars = new List<Car>();
                List<Truck> trucks = new List<Truck>();

            while (line != "end")
            {
                string[] tokens = line.Split('/');

                string type = tokens[0];
                string brand = tokens[1];
                string model = tokens[2];
                double horsePowerOrWeight = double.Parse(tokens[3]);


                if (type == "Car")
                {
                    Car car = new Car
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = horsePowerOrWeight
                    };
                    cars.Add(car);                    
                }
                else if (type == "Truck")
                {
                    Truck truck = new Truck
                    {
                        Brand = brand,
                        Model = model,
                        Weight = horsePowerOrWeight
                    };
                    trucks.Add(truck);
                }
                line = Console.ReadLine();
            }

            Catalog catalog = new Catalog
            {
                Cars = cars,
                Trucks = trucks
            };

            if (cars.Count != 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car car in catalog.Cars.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (trucks.Count != 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck truck in catalog.Trucks.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }
}
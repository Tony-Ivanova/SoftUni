namespace CarManufacturer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var tires = new List<Tire[]>();
            var engines = new List<Engine>();
            var cars = new List<Car>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "No more tires")
                {
                    break;
                }

                string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Tire tire1 = new Tire(int.Parse(tokens[0]), double.Parse(tokens[1]));
                Tire tire2 = new Tire(int.Parse(tokens[2]), double.Parse(tokens[3]));
                Tire tire3 = new Tire(int.Parse(tokens[4]), double.Parse(tokens[5]));
                Tire tire4 = new Tire(int.Parse(tokens[6]), double.Parse(tokens[7]));

                Tire[] tireSet = new Tire[4]
                {
                    tire1, tire2, tire3, tire4
                };

                tires.Add(tireSet);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Engines done")
                {
                    break;
                }

                string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Engine currentEngine = new Engine(int.Parse(tokens[0]), double.Parse(tokens[1]));
                engines.Add(currentEngine);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Show special")
                {
                    break;
                }

                string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string currentMake = tokens[0];
                string currentModel = tokens[1];
                int currentYear = int.Parse(tokens[2]);
                double currentQuanity = double.Parse(tokens[3]);
                double currentConsumtion = double.Parse(tokens[4]);

                int askedTiresSet = int.Parse(tokens[5]);
                int askedEngine = int.Parse(tokens[6]);

                Car car = new Car(currentMake, currentModel, currentYear, currentQuanity, currentConsumtion, engines[askedEngine], tires[askedTiresSet]);

                cars.Add(car);

                input = Console.ReadLine();
            }

            var filteredCars = cars.FindAll(x => x.Year >= 2017
                                             && x.Engine.HorsePower > 330
                                             && x.Tires.Select(y => y.Pressure).Sum() > 9
                                             && x.Tires.Select(y => y.Pressure).Sum() < 10).ToList();

            for (int i = 0; i < filteredCars.Count; i++)
            {
                filteredCars[i].Drive(20);
            }

            foreach (var specialCar in filteredCars)
            {
                Console.WriteLine($"Make: {specialCar.Make}");
                Console.WriteLine($"Model: {specialCar.Model}");
                Console.WriteLine($"Year: {specialCar.Year}");
                Console.WriteLine($"HorsePowers: {specialCar.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {specialCar.FuelQuantity}");
            }
        }
    }
}

namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Car> cars = new List<Car>();
            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                var tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                int speed = int.Parse(tokens[1]);
                int power = int.Parse(tokens[2]);
                int weight = int.Parse(tokens[3]);
                string type = tokens[4];

                Tire[] tireSet = new Tire[4];
                int count = 0;

                for (int j = 5; j < tokens.Length; j += 2)
                {
                    double tirePressure = double.Parse(tokens[i]);
                    int tireAge = int.Parse(tokens[i + 1]);

                    Tire currentTire = new Tire(tirePressure, tireAge);
                    tireSet[count] = currentTire;
                }

                Engine engine = new Engine(speed, power);

                Cargo cargo = new Cargo(weight, type);

                Car car = new Car(model, engine, cargo, tireSet);

                cars.Add(car);

            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else
            {
                foreach (var car in cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }

        }
    }
}

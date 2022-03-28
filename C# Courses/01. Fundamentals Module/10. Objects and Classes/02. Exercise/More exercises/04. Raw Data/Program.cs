namespace _04._Raw_Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }      
    }

    public class Cargo
    {
        public Cargo(int weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }

        public int Weight { get; set; }
        public string Type { get; set; }
    }

    public class Engine
    {

        public Engine(int speed, int power)
        {
            this.Power = power;
            this.Speed = speed;
        }

        public int Speed { get; set; }

        public int Power { get; set; }
    }


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
               
                Engine engine = new Engine(speed, power);

                Cargo cargo = new Cargo(weight, type); 
                Car car = new Car(model, engine, cargo);

                cars.Add(car);

            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in cars.Where(x => x.Cargo.Type == "fragile" && x.Cargo.Weight < 1000))
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

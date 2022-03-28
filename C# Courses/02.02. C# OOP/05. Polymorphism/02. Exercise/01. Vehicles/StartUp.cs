namespace _01._Vehicles
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            var car = Console.ReadLine()
                             .Split();

            var carFuelQuantity = double.Parse(car[1]);
            var carFuelConsumption = double.Parse(car[2]);

            var currentCar = new Car(carFuelQuantity, carFuelConsumption);


            var truck = Console.ReadLine()
                               .Split();

            var truckFuelQuantity = double.Parse(truck[1]);
            var truckFuelConsumption = double.Parse(truck[2]);

            var currentTruck = new Truck(truckFuelQuantity, truckFuelConsumption);

            var numberCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberCommands; i++)
            {
                var tokens = Console.ReadLine()
                                    .Split();

                var command = tokens[0];
                var type = tokens[1];

                if (command == "Drive")
                {
                    var distance = double.Parse(tokens[2]);

                    if (type == "Car")
                    {
                        Console.WriteLine(currentCar.Drive(distance));
                    }
                    else
                    {
                        Console.WriteLine(currentTruck.Drive(distance));
                    }
                }
                else
                {
                    double fuelAmount = double.Parse(tokens[2]);

                    if (type == "Car")
                    {
                        currentCar.Refuel(fuelAmount);
                    }
                    else
                    {
                        currentTruck.Refuel(fuelAmount);
                    }
                }
            }

            Console.WriteLine(currentCar);
            Console.WriteLine(currentTruck);
        }
    }
}

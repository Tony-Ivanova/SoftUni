namespace _02._Vehicles_Extension
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var vehicles = new List<Vehicle>();

            for (int i = 1; i <= 3; i++)
            {
                var vehicleInput = Console.ReadLine().Split();
                var fuelQuantity = double.Parse(vehicleInput[1]);
                var fuelConsumption = double.Parse(vehicleInput[2]);
                var tankCapacity = int.Parse(vehicleInput[3]);

                Vehicle vehicle = null;

                if (i == 1)
                {
                    vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
                }
                else if (i == 2)
                {
                    vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);

                }
                else
                {
                    vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);

                }
                vehicles.Add(vehicle);
            }



            int numberCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberCommands; i++)
            {
                var tokens = Console.ReadLine().Split();

                var command = tokens[0];
                var type = tokens[1];

                if (command == "Drive")
                {
                    var distance = double.Parse(tokens[2]);

                    var currentVehicle = vehicles.FirstOrDefault(x => x.GetType().Name == type);
                    Console.WriteLine(currentVehicle.Drive(distance));
                }
                else if (command == "Refuel")
                {
                    var fuelAmount = double.Parse(tokens[2]);
                    var currentVehicle = vehicles.FirstOrDefault(x => x.GetType().Name == type);

                    try
                    {
                        currentVehicle.Refuel(fuelAmount);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    var distance = double.Parse(tokens[2]);
                    var currentVehicle = (Bus)vehicles.FirstOrDefault(x => x.GetType().Name == type);

                    Console.WriteLine(currentVehicle.DriveEmpty(distance));
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}


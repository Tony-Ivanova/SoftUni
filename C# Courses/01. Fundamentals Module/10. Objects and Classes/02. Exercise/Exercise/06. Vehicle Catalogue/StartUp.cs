namespace _06._Vehicle_Catalogue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Vehicle
    {
        public string VehicleType { get; set; }

        public string VehicleModel { get; set; }

        public string VehicleColour { get; set; }

        public int VehicleHorsepower { get; set; }
    }

    public class StartUp
    {
        public static void Main()
        {
            List<Vehicle> listOfVehicles = new List<Vehicle>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] tokens = input.Split();
                string type = tokens[0].ToLower();

                if (type == "car")
                {
                    type = "Car";
                }
                else
                {
                    type = "Truck";
                }

                string model = tokens[1];
                string colour = tokens[2];
                int power = int.Parse(tokens[3]);
                Vehicle vehicle = new Vehicle();

                vehicle.VehicleType = type;
                vehicle.VehicleModel = model;
                vehicle.VehicleColour = colour;
                vehicle.VehicleHorsepower = power;
                listOfVehicles.Add(vehicle);
            }
            string command = Console.ReadLine();
            while (true)
            {
                if (command == "Close the Catalogue")
                {
                    break;
                }

                Vehicle vehicle = listOfVehicles.Where(x => x.VehicleModel == command).First();
                Console.WriteLine($"Type: {vehicle.VehicleType}");
                Console.WriteLine($"Model: {vehicle.VehicleModel}");
                Console.WriteLine($"Color: {vehicle.VehicleColour}");
                Console.WriteLine($"Horsepower: {vehicle.VehicleHorsepower}");
                command = Console.ReadLine();
            }

            if (listOfVehicles.Where(x => x.VehicleType == "Car").Count() > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: " +
                                    $"{listOfVehicles.Where(x => x.VehicleType == "Car").Select(x => x.VehicleHorsepower).Average():F2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: 0.00."); 
            }
            if (listOfVehicles.Where(x => x.VehicleType == "Truck").Count() > 0)

            {
                Console.WriteLine($"Trucks have average horsepower of: {listOfVehicles.Where(x => x.VehicleType == "Truck").Select(x => x.VehicleHorsepower).Average():f2}.");

            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: 0.00.");
            }
        }
    }
}

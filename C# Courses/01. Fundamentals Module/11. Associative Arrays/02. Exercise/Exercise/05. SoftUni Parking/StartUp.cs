namespace _05._SoftUni_Parking
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var carsAndOwners = new Dictionary<string, string>();

            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine();
                var tokens = input.Split();

                var isRegistered = tokens[0];
                var name = tokens[1];

                if (isRegistered == "register")
                {
                    var plate = tokens[2];

                    if (!carsAndOwners.ContainsKey(name))
                    {
                        carsAndOwners[name] = plate;
                        Console.WriteLine($"{name} registered {plate} successfully");
                    }
                    else
                    {
                        string alreadyUsed = carsAndOwners[name];
                        Console.WriteLine($"ERROR: already registered with plate number {alreadyUsed}");
                    }
                }
                else if (isRegistered == "unregister")
                {
                    if (!carsAndOwners.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                    else
                    {
                        Console.WriteLine($"{name} unregistered successfully");
                        carsAndOwners.Remove(name);
                    }
                }
            }

            foreach (var kvp in carsAndOwners)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}

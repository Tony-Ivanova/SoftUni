namespace _01._Train
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] tokens = line.Split();
                string command = tokens[0];

                if (command == "Add")
                {
                    int wagonsToAdd = int.Parse(tokens[1]);
                    wagons.Add(wagonsToAdd);
                }
                else
                {
                    int passangersToAdd = int.Parse(tokens[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + passangersToAdd <= maxCapacity)
                        {
                            wagons[i] += passangersToAdd;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}

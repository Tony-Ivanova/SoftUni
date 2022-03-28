namespace _03._House_Party
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string line = Console.ReadLine();

                string[] tokens = line.Split();

                if (tokens.Length == 3)
                {
                    string nameToAdd = tokens[0];

                    if (guests.Contains(nameToAdd))
                    {
                        Console.WriteLine($"{nameToAdd} is already in the list!");
                    }
                    else
                    {
                        guests.Add(nameToAdd);
                    }
                }

                else if (tokens.Length == 4)
                {
                    string nameToRemove = tokens[0];

                    if (guests.Contains(nameToRemove))
                    {
                        guests.Remove(nameToRemove);
                    }
                    else
                    {
                        Console.WriteLine($"{nameToRemove} is not in the list!");
                    }
                }
            }

            Console.Write(string.Join(Environment.NewLine, guests));
        }
    }
}

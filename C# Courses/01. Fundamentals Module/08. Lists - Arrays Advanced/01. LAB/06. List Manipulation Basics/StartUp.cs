namespace _06._List_Manipulation_Basics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] tokens = line.Split();

                string command = tokens[0];
                int number = int.Parse(tokens[1]);

                switch (command)
                {
                    case "Add":
                        numbers.Add(number);
                        break;
                    case "Remove":
                        numbers.Remove(number);
                        break;
                    case "RemoveAt":                        
                        numbers.RemoveAt(number);
                        break;
                    case "Insert":                        
                        int indexToInsert = int.Parse(tokens[2]);
                        numbers.Insert(indexToInsert, number);
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", numbers)); 
        }
    }
}

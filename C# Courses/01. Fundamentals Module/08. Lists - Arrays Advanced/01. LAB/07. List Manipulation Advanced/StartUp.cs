namespace _07._List_Manipulation_Advanced
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

            List<int> numbersOriginal = new List<int>(numbers);

            List<int> result = new List<int>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end") 
                {
                    break;
                }

                string[] tokens = line.Split();

                string command = tokens[0];

                switch (command)
                {
                    case "Add":
                        int numberToAdd = int.Parse(tokens[1]); 
                        numbers.Add(numberToAdd);
                        break;
                    case "Remove":
                        int numberToRemove = int.Parse(tokens[1]);
                        numbers.Remove(numberToRemove);
                        break;
                    case "RemoveAt":
                        int numberToRemoveAt = int.Parse(tokens[1]);
                        numbers.RemoveAt(numberToRemoveAt);
                        break;
                    case "Insert":                       
                        int numberToInsert = int.Parse(tokens[1]);
                        int indexToInsert = int.Parse(tokens[2]);
                        numbers.Insert(indexToInsert, numberToInsert);
                        break;
                    case "Contains":
                        int containsNumber = int.Parse(tokens[1]); 
                        if (numbers.Contains(containsNumber))
                        {
                            Console.WriteLine($"Yes");
                        }
                        else
                        {
                            Console.WriteLine($"No such number");
                        }
                        break;
                    case "PrintEven":
                        int[] resultEven = numbers.Where(n => n % 2 == 0).ToArray();
                        PrintingTheCurrentArray(resultEven);
                        break;
                    case "PrintOdd":
                        int[] resultNewOdd = numbers.Where(n => n % 2 != 0).ToArray();
                        PrintingTheCurrentArray(resultNewOdd);
                        break;
                    case "GetSum":
                        Console.WriteLine(numbers.Sum());
                        break;
                    case "Filter":                          
                        string condition = tokens[1];
                        int numberCondition = int.Parse(tokens[2]);
                        if (condition == "<")
                        {
                            int[] condition1 = numbers.Where(x => x < numberCondition).ToArray();
                            PrintingTheCurrentArray(condition1);
                        }
                        else if (condition == ">")
                        {
                            int[] condition2 = numbers.Where(x => x > numberCondition).ToArray();
                            PrintingTheCurrentArray(condition2);
                        }
                        else if (condition == ">=")
                        {
                            int[] condition3 = numbers.Where(x => x >= numberCondition).ToArray();
                            PrintingTheCurrentArray(condition3);
                        }
                        else if (condition == "<=")
                        {
                            int[] condition4 = numbers.Where(x => x <= numberCondition).ToArray();
                            PrintingTheCurrentArray(condition4);
                        }
                        break;
                }
            }
            if (!numbersOriginal.SequenceEqual(numbers))
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        private static void PrintingTheCurrentArray(int[] array)
        {
            Console.WriteLine(string.Join(" ", array));
        }
    }
}

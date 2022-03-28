namespace _04._List_Operations
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

                if (line == "End")
                {
                    break;
                }

                string[] tokens = line.Split();
                string command = tokens[0];

                switch (command)
                {
                    case "Add":
                        int numbersToAdd = int.Parse(tokens[1]);
                        numbers.Add(numbersToAdd);
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(tokens[1]);
                        int myIndex = int.Parse(tokens[2]);
                        if (myIndex >= 0 && myIndex <= numbers.Count)
                        {
                            numbers.Insert(myIndex, numberToInsert);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case "Remove":
                        int indexToRemove = int.Parse(tokens[1]);
                        if (indexToRemove >= 0 && indexToRemove <= numbers.Count)
                        {
                            numbers.RemoveAt(indexToRemove);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case "Shift":
                        if (tokens[1] == "left")
                        {
                            int countLeft = int.Parse(tokens[2]);
                            numbers = Left(numbers, countLeft);
                        }
                        else if (tokens[1] == "right")
                        {
                            int countRight = int.Parse(tokens[2]);
                            numbers = Right(numbers, countRight);
                        }
                        break;

                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
        private static List<int> Left(List<int> numbers, int countLeft)
        {
            if (countLeft < numbers.Count)
            {
                countLeft %= numbers.Count;
            }
            for (int i = 0; i < countLeft; i++)
            {
                numbers.Add(numbers[0]);
                numbers.Remove(numbers[0]);
            }
            return numbers;
        }

        private static List<int> Right(List<int> numbers, int countRight)
        {
            if (countRight > numbers.Count)
            {
                countRight %= numbers.Count;
            }
            for (int i = 0; i < countRight; i++)
            {
                numbers.Insert(0, numbers[numbers.Count - 1]);
                numbers.RemoveAt(numbers.Count - 1);
            }
            return numbers;
        }
    }
}

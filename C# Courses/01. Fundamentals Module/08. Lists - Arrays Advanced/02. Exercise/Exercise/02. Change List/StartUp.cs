namespace _02._Change_List
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
                    case "Delete":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (number == numbers[i])
                            {
                                numbers.Remove(numbers[i]);
                            }
                        }
                        break;
                    case "Insert":
                        int indexMy = int.Parse(tokens[2]);
                        numbers.Insert(indexMy, number);
                        break;
                }

            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

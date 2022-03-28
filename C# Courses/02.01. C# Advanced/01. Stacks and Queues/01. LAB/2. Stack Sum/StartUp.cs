namespace _2._Stack_Sum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                                   .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            while (true)
            {
                string input = Console.ReadLine()
                                      .ToLower();

                if (input == "end")
                {
                    break;
                }

                string[] tokens = input.Split();
                string command = tokens[0].ToLower();

                if (command == "add")
                {
                    stack.Push(int.Parse(tokens[1]));
                    stack.Push(int.Parse(tokens[2]));
                }
                else if (command == "remove")
                {
                    int howManyNumbers = int.Parse(tokens[1]);

                    if (stack.Count < howManyNumbers)
                    {
                        continue;
                    }
                    else
                    {
                        for (int i = 0; i < howManyNumbers; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }

            int sum = stack.Sum();
            
            Console.WriteLine($"Sum: {sum}");
        }
    }
}

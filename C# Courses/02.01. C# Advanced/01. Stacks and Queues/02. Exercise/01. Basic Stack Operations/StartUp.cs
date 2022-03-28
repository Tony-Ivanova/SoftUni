namespace _01._Basic_Stack_Operations
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
            int toPush = numbers[0];
            int toPop = numbers[1];
            int toLookFor = numbers[2];

            int[] input = Console.ReadLine()
                               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < toPush; i++)
            {
                int currentNumber = input[i];
                stack.Push(currentNumber);
            }

            for (int i = 0; i < toPop; i++)
            {
                stack.Pop();
            }

            string result = string.Empty;

            if (stack.Contains(toLookFor))
            {
                result = "true";
            }
            else if (stack.Count == 0)
            {
                result = "0";
            }
            else
            {
                int minimum = stack.Min();
                result = minimum.ToString();
            }

            Console.WriteLine(result);
        }
    }
}

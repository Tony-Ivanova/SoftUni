namespace _05._Fashion_Boutique
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] boxOfClothes = Console.ReadLine()
                                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();
            int rack = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>(boxOfClothes);

            int sum = 0;
            int numberOfRacks = 1;

            while (stack.Any())
            {
                if (sum + stack.Peek() <= rack)
                {
                    sum += stack.Pop();
                }
                else
                {
                    sum = 0;
                    numberOfRacks++;
                }
            }

            Console.WriteLine(numberOfRacks);
        }
    }
}

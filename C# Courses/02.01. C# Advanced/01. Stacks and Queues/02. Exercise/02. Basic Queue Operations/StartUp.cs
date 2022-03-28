namespace _02._Basic_Queue_Operations
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
            Queue<int> que = new Queue<int>();

            for (int i = 0; i < toPush; i++)
            {
                int currentNumber = input[i];
                que.Enqueue(currentNumber);
            }

            for (int i = 0; i < toPop; i++)
            {
                que.Dequeue();
            }

            if (que.Contains(toLookFor))
            {
                Console.WriteLine("true");
            }
            else if (que.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                int minimum = que.Min();
                Console.WriteLine(minimum);
            }
        }
    }
}

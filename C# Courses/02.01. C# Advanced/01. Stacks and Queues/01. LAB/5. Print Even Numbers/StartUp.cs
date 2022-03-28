namespace _5._Print_Even_Numbers
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

            Queue<int> queue = new Queue<int>(numbers);
            Queue<int> evenNumber = new Queue<int>();

            while(queue.Any())
            {
                var currentNumber = queue.Dequeue();

                if (currentNumber % 2 == 0)
                {            
                    evenNumber.Enqueue(currentNumber);
                }
            }

            evenNumber.Reverse();
            Console.WriteLine(string.Join(", ", evenNumber));
        }
    }
}

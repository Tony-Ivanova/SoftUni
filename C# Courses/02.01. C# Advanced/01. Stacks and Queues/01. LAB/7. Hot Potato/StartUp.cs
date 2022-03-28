namespace _7._Hot_Potato
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var children = Console.ReadLine()
                                  .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int number = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(children);
            int counter = 1;

            while (queue.Count > 1)
            {
                var currentChild = queue.Dequeue();

                if (counter % number != 0)
                {
                    queue.Enqueue(currentChild);
                }
                else
                {
                    Console.WriteLine($"Removed {currentChild}");
                }

                counter++;
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}

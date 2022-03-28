namespace _6._Supermarket
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            Queue<string> queue = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    Console.WriteLine($"{queue.Count} people remaining.");
                    break;
                }
                else if (input == "Paid")
                {
                    while (queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }
        }
    }
}

namespace _06._Songs_Queue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] songs = Console.ReadLine()
                            .Split(", ");

            Queue<string> queue = new Queue<string>(songs);

            while (true)
            {
                if (!queue.Any())
                {
                    Console.WriteLine("No more songs!");
                    break;
                }

                string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, 2);
                string command = tokens[0];

                if(command == "Play")
                {
                    queue.Dequeue();
                }
                else if(command == "Add")
                {                    
                    string song = tokens[1];

                    if (queue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(song);
                    }
                }
                else if(command == "Show")
                {
                    Console.WriteLine(string.Join(", ", queue));
                }
            }
        }
    }
}

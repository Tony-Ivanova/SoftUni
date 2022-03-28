namespace _8._Traffic_Jam
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int numbersPassing = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            int counter = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    Console.WriteLine($"{counter} cars passed the crossroads.");
                    break;
                }
                else if (input == "green")
                {
                    var carToPass = Math.Min(numbersPassing, queue.Count);
                   
                    for (int i = 0; i < carToPass; i++)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        counter++;
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

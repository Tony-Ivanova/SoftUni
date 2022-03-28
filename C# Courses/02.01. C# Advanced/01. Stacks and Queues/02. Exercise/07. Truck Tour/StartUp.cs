﻿namespace _07._Truck_Tour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int pumpsCount = int.Parse(Console.ReadLine());
            int index = 0;
            Queue<int> difference = new Queue<int>();

            for (int i = 0; i < pumpsCount; i++)
            {
                int[] pumpProps = Console.ReadLine()
                                       .Split()
                                       .Select(int.Parse)
                                       .ToArray();

                difference.Enqueue(pumpProps[0] - pumpProps[1]);
            }

            while (true)
            {
                Queue<int> copyDifference = new Queue<int>(difference);
                int fuel = -1;

                while (copyDifference.Any())
                {
                    if (copyDifference.Peek() > 0 && fuel == -1)
                    {
                        fuel = copyDifference.Dequeue();
                        difference.Enqueue(difference.Dequeue());
                    }
                    else if (copyDifference.Peek() < 0 && fuel == -1)
                    {
                        copyDifference.Enqueue(copyDifference.Dequeue());
                        difference.Enqueue(difference.Dequeue());
                        index++;
                    }
                    else
                    {
                        fuel += copyDifference.Dequeue();
                        if (fuel < 0)
                        {
                            break;
                        }
                    }
                }
                if (fuel >= 0)
                {
                    Console.WriteLine(index);
                    return;
                }
                index++;
            }
        }
    }
}

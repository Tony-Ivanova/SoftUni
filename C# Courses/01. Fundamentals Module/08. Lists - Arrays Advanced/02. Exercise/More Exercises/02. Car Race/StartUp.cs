namespace _02._Car_Race
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var firstRacer = numbers;
            var secondRacer = numbers
                .Reverse()
                .ToArray();

            double sumFirst = 0;
            double sumSecond = 0;

            for (int i = 0; i < firstRacer.Length / 2; i++)
            {
                if (firstRacer[i] == 0)
                {
                    sumFirst *= 0.8;
                }
                else
                {
                    sumFirst += firstRacer[i];
                }
            }

            for (int i = 0; i < secondRacer.Length / 2; i++)
            {
                {
                    if (secondRacer[i] == 0)
                    {
                        sumSecond *= 0.8;
                    }
                    else
                    {
                        sumSecond += secondRacer[i];
                    }
                }
            }
            if (sumFirst < sumSecond)
            {
                Console.WriteLine($"The winner is left with total time: {sumFirst}");
            }

            else
            {
                Console.WriteLine($"The winner is right with total time: {sumSecond}");
            }
        }
    }
}

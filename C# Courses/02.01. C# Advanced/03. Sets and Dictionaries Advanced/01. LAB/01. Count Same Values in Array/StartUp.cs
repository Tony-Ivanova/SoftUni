namespace _01._Count_Same_Values_in_Array
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            double[] nums = Console.ReadLine()
                                   .Split(' ')
                                   .Select(double.Parse)
                                   .ToArray();

            Dictionary<double, int> counts = new Dictionary<double, int>();

            foreach (var num in nums)
            {
                if (!counts.ContainsKey(num))
                {
                    counts[num] = 1;
                }
                else
                {
                    counts[num]++;
                }
            }

            foreach (var num in counts)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}

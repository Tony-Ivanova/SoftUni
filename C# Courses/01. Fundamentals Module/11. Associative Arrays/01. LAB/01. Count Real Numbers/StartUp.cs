namespace _01._Count_Real_Numbers
{

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] nums = Console.ReadLine()
                                .Split(' ')
                                .Select(int.Parse)
                                .ToArray();

            SortedDictionary<int, int> counts = new SortedDictionary<int, int>();

            foreach (var num in nums)
            {
                if (counts.ContainsKey(num))
                {
                    counts[num]++;
                }
                else
                {
                    counts[num] = 1;
                }
            }

            foreach (var num in counts)
            {
                Console.WriteLine($"{num.Key} -> {num.Value}");
            }
        }
    }
}

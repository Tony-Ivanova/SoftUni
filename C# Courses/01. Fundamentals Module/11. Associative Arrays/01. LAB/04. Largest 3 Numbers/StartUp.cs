namespace _04._Largest_3_Numbers
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
                                   .OrderByDescending(n => n)
                                   .ToArray();

            int count = numbers.Length >= 3 ? 3 : numbers.Length;

            for (int i = 0; i < count; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
        }
    }
}

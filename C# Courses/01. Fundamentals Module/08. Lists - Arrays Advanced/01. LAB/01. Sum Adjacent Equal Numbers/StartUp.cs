namespace _01._Sum_Adjacent_Equal_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<double> numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    numbers[i] += numbers[i + 1];
                    numbers.RemoveAt(i + 1);
                    i = -1; //reset the loop    
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

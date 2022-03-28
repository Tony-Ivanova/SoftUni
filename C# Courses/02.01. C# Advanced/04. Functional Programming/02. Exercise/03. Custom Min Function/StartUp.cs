namespace _03._Custom_Min_Function
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Func<string, int> parser = x => int.Parse(x);

            var numbers = Console.ReadLine()
                                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(parser)
                                 .ToList();

            Func<List<int>, int> minFunction = MinNumber;

            var minNumber = MinNumber(numbers);

            Console.WriteLine(minNumber);
        }

        private static int MinNumber(List<int> numbers)
        {
            int temp = int.MaxValue;

            foreach (var num in numbers)
            {
                if (num < temp)
                {
                    temp = num;
                }
            }

            return temp;
        }
    }
}
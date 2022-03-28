namespace _01._Sort_Numbers
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = new List<int>();

            for (int i = 1; i <= 3; i++)
            {
                var number = int.Parse(Console.ReadLine());

                numbers.Add(number);
            }

            numbers.Sort();
            numbers.Reverse();

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}

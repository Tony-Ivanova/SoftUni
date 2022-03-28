namespace _04._Find_Evens_or_Odds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> range = Console.ReadLine()
                               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();

            int start = range[0];
            int end = range[1];

            string typenumber = Console.ReadLine();

            List<int> number = new List<int>();

            Predicate<int> filter = x => typenumber == "odd" ? x % 2 != 0 : x % 2 == 0;

            for (int i = start; i <= end; i++)
            {
                number.Add(i);
            }

            Console.WriteLine(string.Join(" ", number.Where(x => filter(x))));
        }
    }
}
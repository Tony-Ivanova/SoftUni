namespace _06._Reverse_And_Exclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> number = Console.ReadLine()
                                      .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .Reverse()
                                      .ToList();

            int divide = int.Parse(Console.ReadLine());

            Func<List<int>, List<int>> divFunc = x => x.Where(a => a % divide != 0).ToList();

            List<int> newList = divFunc(number);

            Console.WriteLine(string.Join(" ", newList));
        }
    }
}
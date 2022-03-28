namespace _05._Remove_Negatives_and_Reverse
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToList();

            numbers.RemoveAll(n => n < 0);

            if (numbers.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}

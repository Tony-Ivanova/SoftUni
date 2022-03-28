namespace _01._Sort_Even_Numbers
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                           .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(int.Parse)
                           .Where(x => x % 2 == 0)
                           .OrderBy(x => x)
                           .ToArray();

            string result = string.Join(", ", numbers);
            Console.WriteLine(result);
        }
    }
}

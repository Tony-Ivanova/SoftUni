namespace _02._Sum_Numbers
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            int[] numbers = input.Split(new char[] { ',', ' ' },
                                         StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse).ToArray();

            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }
    }
}
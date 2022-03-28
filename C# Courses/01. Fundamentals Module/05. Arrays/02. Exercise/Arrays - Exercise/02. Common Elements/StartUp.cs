namespace _02._Common_Elements
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] firstArray = Console.ReadLine()
                .Split(' ')
                .ToArray();

            string[] secondArray = Console.ReadLine()
                .Split(' ')
                .ToArray();

            string result = string.Empty;

            var common = secondArray.Intersect(firstArray);

            foreach (string value in common)
            {
                result += value + " ";
            }

            Console.WriteLine(result);
        }
    }
}

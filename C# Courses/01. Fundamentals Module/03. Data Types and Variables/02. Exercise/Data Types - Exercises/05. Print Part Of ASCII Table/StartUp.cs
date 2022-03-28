namespace _05._Print_Part_Of_ASCII_Table
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int startIndex = int.Parse(Console.ReadLine());
            int endIndex = int.Parse(Console.ReadLine());

            var result = string.Empty;

            for (int i = startIndex; i <= endIndex; i++)
            {
                result += $"{(char)i} ";
            }

            Console.WriteLine(result);
        }
    }
}

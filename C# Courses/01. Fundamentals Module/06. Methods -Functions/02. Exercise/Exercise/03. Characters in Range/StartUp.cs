namespace _03._Characters_in_Range
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            string result = charactersInRange(firstChar, secondChar);
            Console.WriteLine(result);
        }
        private static string charactersInRange(char firstChar, char secondChar)
        {
            string result = string.Empty;

            int firstCharNew = Math.Min(firstChar, secondChar);
            int secondCharNew = Math.Max(firstChar, secondChar);

            for (int i = firstCharNew + 1; i < secondCharNew; i++)
            {
                result += ((char)i + " ");
            }
            return result;
        }

    }
}
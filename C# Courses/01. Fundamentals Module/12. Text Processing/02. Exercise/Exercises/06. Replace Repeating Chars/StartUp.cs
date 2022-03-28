namespace _06._Replace_Repeating_Chars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<char> chars = input.ToList();

            for (int i = 1; i < chars.Count; i++)
            {
                if (chars[i] == chars[i - 1])
                {
                    chars.RemoveAt(i);
                    i--;
                }
            }

            Console.WriteLine(string.Join("", chars));
        }
    }
}

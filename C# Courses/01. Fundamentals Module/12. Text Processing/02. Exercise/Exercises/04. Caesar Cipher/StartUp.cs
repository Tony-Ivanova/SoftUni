namespace _04._Caesar_Cipher
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            char[] chars = input.ToCharArray();
            int newI = 0;

            List<char> result = new List<char>();

            for (int i = 0; i < chars.Length; i++)
            {
                newI = chars[i];
                char newChar = (char)(newI + 3);
                result.Add(newChar);
            }

            Console.WriteLine(string.Join("", result));
        }
    }
}
namespace _04._Reverse_Array_of_Strings
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            string[] words = Console.ReadLine()
                .Split(" ");

            for (int i = words.Length - 1; i >= 0; i--)
            {
                Console.Write(words[i] + " ");
            }
            Console.WriteLine();
        }
    }
}

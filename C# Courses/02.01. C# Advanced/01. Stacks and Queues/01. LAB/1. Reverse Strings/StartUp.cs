namespace _1._Reverse_Strings
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            foreach (var letter in input)
            {
                stack.Push(letter);
            }

            while (stack.Count != 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}

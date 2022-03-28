namespace _4._Matching_Brackets
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (currentChar == '(')
                {
                    stack.Push(i);
                }
                else if (currentChar == ')')
                {
                    int startIndex = stack.Pop();
                    string content = input.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(content);
                }
            }
        }
    }
}

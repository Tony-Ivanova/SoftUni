namespace _3._Simple_Calculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                int first = int.Parse(stack.Pop());
                string opera = stack.Pop();
                int second = int.Parse(stack.Pop());

                if (opera == "-")
                {
                    stack.Push((first - second).ToString());
                }
                else if (opera == "+")
                {
                    stack.Push((first + second).ToString());
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}

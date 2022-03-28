namespace _08._Balanced_Parenthesis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray();
            Stack<char> que = new Stack<char>();
            bool isIt = false;

            if (input.Count() % 2 != 0 || input.Count() == 0)
            {
                Console.WriteLine("NO");
                return;
            }
            else if (input.Count() % 2 == 0)
            {
                for (int i = 0; i < input.Count() - 1; i++)
                {
                    if (input[i] == ')' && input[i + 1] == '(')
                    {
                        continue;
                    }
                    else if ((input[i] == '(') || 
                             (input[i] == '{') || 
                             (input[i] == '['))
                    {
                        char currentChar = input[i];
                        que.Push(currentChar);
                    }
                    else if ((que.Peek() == '(' && input[i] == ')') ||
                            (que.Peek() == '[' && input[i] == ']') ||
                            (que.Peek() == '{' && input[i] == '}'))
                    {
                        que.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        isIt = true;
                        break;
                    }
                }

                if (isIt == false)
                {
                    Console.WriteLine("YES");
                }
            }
        }
    }
}

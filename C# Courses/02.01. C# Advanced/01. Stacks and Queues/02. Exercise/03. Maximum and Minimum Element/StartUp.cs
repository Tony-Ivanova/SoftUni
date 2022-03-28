namespace _03._Maximum_and_Minimum_Element
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            if (number >= 1 && number <= 105)
            {
                for (int i = 0; i < number; i++)
                {
                    string[] tokens = Console.ReadLine()
                                             .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int command = int.Parse(tokens[0]);

                    if (command == 1)
                    {
                        int withHowMany = int.Parse(tokens[1]);

                        if (withHowMany >= 1 && withHowMany <= 109)
                        {
                            stack.Push(withHowMany);
                        }
                    }
                    else if (command == 2)
                    {
                        if (stack.Count != 0)
                        {
                            stack.Pop();
                        }
                    }
                    else if (command == 3 && stack.Count != 0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                    else if (command == 4 && stack.Count != 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                    else
                    {
                        continue;
                    }
                }

                Console.WriteLine(string.Join(", ", stack));
            }
        }
    }
}

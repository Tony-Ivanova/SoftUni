namespace _09._Simple_Text_Editor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            int numberOfOperations = int.Parse(Console.ReadLine());

            Stack<string> stack = new Stack<string>();
            StringBuilder text = new StringBuilder();

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] tokens = Console.ReadLine()
                                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                switch (command)
                {
                    case "1":
                        stack.Push(text.ToString());
                        string textToAdd = tokens[1];
                        text.Append(textToAdd);
                        break;
                    case "2":
                        stack.Push(text.ToString());
                        int removeCount = int.Parse(tokens[1]);
                        text.Remove(text.Length - removeCount, removeCount);
                        break;
                    case "3":
                        int index = int.Parse(tokens[1]) - 1;
                        Console.WriteLine(text[index]);
                        break;
                    case "4":
                        text.Clear();
                        text.Append(stack.Pop());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

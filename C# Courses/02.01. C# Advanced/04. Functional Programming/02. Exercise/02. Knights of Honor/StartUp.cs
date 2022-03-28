namespace _02._Knights_of_Honor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<string> names = Console.ReadLine()
                                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();

            Func<string, string> format = x => $"Sir {x}";

            Action<List<string>> print = x => Console.WriteLine
                                                        (string.Join(Environment.NewLine, x.Select(format)));

            print(names);
        }
    }
}
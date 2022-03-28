namespace _01._Action_Print
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

            Action<List<string>> print = x => Console.WriteLine
                                                     (string.Join(Environment.NewLine, x));
            print(names);
        }
    }
}

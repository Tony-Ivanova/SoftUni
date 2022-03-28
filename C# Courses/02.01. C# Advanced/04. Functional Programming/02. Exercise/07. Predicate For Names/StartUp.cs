namespace _07._Predicate_For_Names
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                               .ToList();

            Predicate<string> predNames = x => x.Count() <= number;

            Action<List<string>> print = x => Console.WriteLine
                                                     (string.Join(Environment.NewLine, names.Where(y => predNames(y))));

            print(names);
        }
    }
}
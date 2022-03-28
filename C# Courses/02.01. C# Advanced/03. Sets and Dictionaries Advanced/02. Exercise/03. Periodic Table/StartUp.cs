namespace _03._Periodic_Table
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            HashSet<string> list = new HashSet<string>();

            for (int i = 0; i < number; i++)
            {
                string[] line = Console.ReadLine()
                                       .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in line)
                {
                    list.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", list.OrderBy(x => x)));
        }
    }
}

namespace _07._Append_Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<string> items = Console.ReadLine()
                .Split('|')
                .ToList();

            items.Reverse();

            var result = new List<string>();

            foreach (var item in items)
            {
                List<string> nums = item
                    .Split(' ')
                    .ToList();

                foreach (var num in nums)
                {
                    if (num != "")
                    {
                        result.Add(num);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}

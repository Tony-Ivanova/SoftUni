namespace _09._List_Of_Predicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int end = int.Parse(Console.ReadLine());

            List<int> dividers = Console.ReadLine()
                                  .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToList();

            List<int> numbers = new List<int>();

            Func<int, int, bool> divFunc = (x, y) => x % y == 0;

            bool isTrue = false;

            for (int i = 1; i <= end; i++)
            {
                foreach (var num in dividers)
                {
                    if (!divFunc(i, num))
                    {
                        isTrue = true;
                        break;
                    }
                }

                if (isTrue == false)
                {
                    numbers.Add(i);
                }

                isTrue = false;
            }

            Action<List<int>> print = x => Console.WriteLine
                                                  (string.Join(" ", numbers));

            print(numbers);
        }
    }
}
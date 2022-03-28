namespace _03._Merging_Lists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> firstNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();

            int minCount = Math.Min(firstNumbers.Count, secondNumbers.Count);

            for (int i = 0; i < minCount; i++)
            {
                result.Add(firstNumbers[i]);
                result.Add(secondNumbers[i]);
            }

            List<int> biggerList;

            if (minCount == firstNumbers.Count)
            {
                biggerList = secondNumbers;
            }
            else
            {
                biggerList = firstNumbers;
            }

            for (int i = minCount; i < biggerList.Count; i++)
            {
                result.Add(biggerList[i]);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}

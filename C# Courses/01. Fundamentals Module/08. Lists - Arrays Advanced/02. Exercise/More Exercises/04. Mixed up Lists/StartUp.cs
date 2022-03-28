namespace _04._Mixed_up_Lists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> firstList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var result = new List<int>();

            secondList.Reverse();

            var shorterList = Math.Min(firstList.Count, secondList.Count);

            for (int i = 0; i < shorterList; i++)
            {
                result.Add(firstList[i]);
                result.Add(secondList[i]);
            }

            List<int> biggerList;

            if (shorterList == firstList.Count)
            {
                biggerList = secondList;
            }
            else
            {
                biggerList = firstList;
            }

            List<int> indexes = new List<int>();

            for (int i = shorterList; i < biggerList.Count; i++)
            {
                indexes.Add(biggerList[i]);
            }

            int start = 0;
            int final = 0;
            if (indexes[0] > indexes[1])
            {
                start = indexes[0];
                final = indexes[1];
            }
            else
            {
                start = indexes[1];
                final = indexes[0];
            }

            List<int> finalList = new List<int>();

            for (int i = 0; i < result.Count; i++)
            {
                int currentnumber = result[i];

                if (currentnumber > final && currentnumber < start)
                {
                    finalList.Add(currentnumber);
                }
            }

            finalList.Sort();

            Console.WriteLine(string.Join(" ", finalList));
        }
    }
}


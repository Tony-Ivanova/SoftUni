namespace _02._Sets_of_Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] tokens = Console.ReadLine()
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
            int n = tokens[0];
            int m = tokens[1];

            var myDicN = new List<int>();
            var myDicM = new List<int>();


            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                myDicN.Add(currentNumber);
            }
            for (int i = 0; i < m; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                myDicM.Add(currentNumber);
            }

            IEnumerable<int> final = myDicN.Intersect(myDicM);

            Console.WriteLine(string.Join(" ", final));
        }
    }
}


namespace _04._Even_Times
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> myDict = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!myDict.ContainsKey(number))
                {
                    myDict[number] = 1;
                }
                else
                {
                    myDict[number]++;
                }
            }

            foreach (var item in myDict.Where(x => x.Value % 2 == 0))
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}


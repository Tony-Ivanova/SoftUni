namespace _05._Top_Integers
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] topInteger = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < topInteger.Length; i++)
            {
                int currentNumber = topInteger[i];

                bool isTopInteger = true;

                for (int j = i + 1; j < topInteger.Length; j++)
                {
                    int nextNumber = topInteger[j];

                    if (topInteger[i] <= topInteger[j])
                    {
                        isTopInteger = false;
                        break;
                    }
                }

                if (isTopInteger)
                {
                    Console.Write(currentNumber + " ");
                }
            }
            Console.WriteLine();
        }
    }
}

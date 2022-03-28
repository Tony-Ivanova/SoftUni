namespace _07._Max_Sequence_of_Equal_Elements
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int initialLength = 1;
            int currentMaxLength = 1;
            int maxNumbbers = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    initialLength++;
                    if (initialLength > currentMaxLength)
                    {
                        currentMaxLength = initialLength;
                        maxNumbbers = numbers[i];
                    }
                }
                else
                {
                    initialLength = 1;
                }
            }

            if (currentMaxLength == 1)
            {
                maxNumbbers = numbers[0];
                Console.WriteLine(maxNumbbers);
            }
            else
            {
                for (int i = 0; i < currentMaxLength; i++)
                {
                    Console.Write(maxNumbbers + " ");
                }
            }

            Console.WriteLine();
        }
    }
}

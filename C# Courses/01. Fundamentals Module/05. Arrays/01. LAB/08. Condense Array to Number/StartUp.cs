namespace _08._Condense_Array_to_Number
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

            int[] condensed = new int[numbers.Length - 1];

            if (numbers.Length == 1)
            {
                Console.WriteLine(numbers[0]);
                return;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < condensed.Length - i; j++)
                {
                    condensed[j] = numbers[j] + numbers[j + 1];
                }
                numbers = condensed;
            }

            Console.WriteLine(condensed[0]);
        }
    }
}

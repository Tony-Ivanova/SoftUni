namespace _04._Fold_and_Sum
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();
            int[] numbers = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                numbers[i] = int.Parse(input[i]);
            }

            int k = input.Length / 4;

            int[] firstKElements = new int[k];
            int[] lastKElements = new int[k];

            for (int i = 0; i < k; i++)
            {
                firstKElements[i] = numbers[i];
                lastKElements[i] = numbers[3 * k + i];
            }

            Array.Reverse(firstKElements);
            Array.Reverse(lastKElements);

            int[] finalArray = new int[2 * k];
            for (int i = 0; i < k; i++)
            {
                finalArray[i] = firstKElements[i] + numbers[k + i];
                finalArray[k + i] = lastKElements[i] + numbers[2 * k + i];
            }

            Console.WriteLine(string.Join(" ", finalArray));
        }
    }
}

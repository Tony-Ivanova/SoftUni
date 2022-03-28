namespace _07._Equal_Arrays
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] arr1 = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] arr2 = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int sum = 0;
            bool isTrue = true;

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    isTrue = false;
                    break;
                }
                else if (arr1[i] == arr2[i])
                {
                    int currentNumber = arr1[i];
                    sum += currentNumber;                   
                }
            }

            if (isTrue == true)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
        }
    }
}

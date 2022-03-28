namespace _06._Equal_Sum
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

            bool isEqual = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;
                
                for (int left = 0; left < i + 1; left++)
                {
                    leftSum += numbers[left];
                }

                for (int right = numbers.Length - 1; right >= i; right--)
                {
                    rightSum += numbers[right];
                }

                if (rightSum == leftSum)
                {
                    Console.WriteLine(i);
                    isEqual = true;
                }

            }
            if (!isEqual)
            {
                Console.WriteLine("no");
            }
        }
    }
}

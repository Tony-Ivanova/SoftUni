namespace _5.__Odd_Times
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int number = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                number ^= array[i];
            }

            Console.WriteLine(number);
        }
    }
}

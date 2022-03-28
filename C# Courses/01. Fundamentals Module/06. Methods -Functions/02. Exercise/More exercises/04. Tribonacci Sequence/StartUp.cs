namespace _04._Tribonacci_Sequence
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                Console.Write(Tribonacci(i) + " ");
            }
        }
        private static long Tribonacci(int number)
        {
            long first = 1;
            long second = 1;
            long third = 2;


            for (int i = 1; i < number; i++)
            {
                long temp = first;
                first = second;
                second = third;
                third = temp + first + second;

            }
            return first;
        }
    }
}
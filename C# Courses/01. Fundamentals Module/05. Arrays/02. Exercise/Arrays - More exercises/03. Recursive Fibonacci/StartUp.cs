namespace _03._Recursive_Fibonacci
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int input = int.Parse(Console.ReadLine()); 

            if (input >= 0 && input <= 50)   
            {
                long sum = 1;
                long fnFirst = 1;
                long fnSecond = 1;

                for (int i = 2; i < input; i++)
                {
                    sum = fnFirst + fnSecond;
                    fnSecond = fnFirst;
                    fnFirst = sum;
                }
                Console.WriteLine(sum);              
            }
        }
    }
}

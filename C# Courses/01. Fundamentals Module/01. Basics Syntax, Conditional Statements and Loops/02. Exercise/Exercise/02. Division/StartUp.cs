namespace _02._Division
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int isDivisible = int.Parse(Console.ReadLine());

            if (isDivisible % 10 == 0)
                Console.WriteLine("The number is divisible by 10");
            else if (isDivisible % 7 == 0)
                Console.WriteLine("The number is divisible by 7");
            else if (isDivisible % 6 == 0)
                Console.WriteLine("The number is divisible by 6");
            else if (isDivisible % 3 == 0)
                Console.WriteLine("The number is divisible by 3");
            else if (isDivisible % 2 == 0)
                Console.WriteLine("The number is divisible by 2");
            else
                Console.WriteLine("Not divisible");
        }
    }
}

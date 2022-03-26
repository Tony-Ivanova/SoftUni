namespace _4._Bit_Destroyer
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int newNumber = 0;

            int mask = 1 << p;
            int result = ~mask;

            newNumber = n & result;
            Console.WriteLine(newNumber);
        }
    }
}

namespace _2._First_Bit
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int shiftedValue = n >> 1;
            Console.WriteLine(shiftedValue & 1);
        }
    }
}

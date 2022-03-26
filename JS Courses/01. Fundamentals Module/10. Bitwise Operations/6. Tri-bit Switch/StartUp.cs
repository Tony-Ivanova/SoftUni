namespace _6._Tri_bit_Switch
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            long mask = (long)7L << p;
            long result = n ^ mask;
            Console.WriteLine(result);
        }
    }
}

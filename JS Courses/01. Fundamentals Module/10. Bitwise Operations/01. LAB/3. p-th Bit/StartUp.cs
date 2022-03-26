namespace _3._p_th_Bit
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int bitAtPositionP = 0;

            int shifted = n >> p;
            int result = shifted & 1;

            if(result == 1)
            {
                bitAtPositionP = 1;
            }
            else
            {
                bitAtPositionP = 0;
            }
            Console.WriteLine(bitAtPositionP);
        }
    }
}

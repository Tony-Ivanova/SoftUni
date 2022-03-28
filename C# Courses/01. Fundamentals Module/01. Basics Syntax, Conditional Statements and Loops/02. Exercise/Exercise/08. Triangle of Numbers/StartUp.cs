namespace _08._Triangle_of_Numbers
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            for (int row = 1; row <= number; row++)
            {

                for (int col = 1; col <= row; col++)
                {
                    Console.Write($"{row} ");
                }

                Console.WriteLine();

            }
        }
    }
}

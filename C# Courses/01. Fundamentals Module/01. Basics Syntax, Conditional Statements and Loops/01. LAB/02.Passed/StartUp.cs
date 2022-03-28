namespace _02.Passed
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            decimal grade = decimal.Parse(Console.ReadLine());

            if (grade >= 3.00m)
                Console.WriteLine("Passed!");
        }
    }
}

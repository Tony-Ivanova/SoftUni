namespace _01._Day_of_Week
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int numberOfDay = int.Parse(Console.ReadLine());

            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            if (numberOfDay >= 1 && numberOfDay <= 7)
            {
                var day = days[numberOfDay - 1];
                Console.WriteLine(day);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}

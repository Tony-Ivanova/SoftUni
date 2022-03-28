namespace _04.Back_in_30_Minutes
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes += 30;
            string zero = string.Empty;

            if (minutes > 59)
            {
                hours += 1;
                minutes -= 60;
            }
            if (hours > 23)
            {
                hours -= 24;
            }
            if (minutes < 10)
            {
                zero = "0";
            }
            Console.WriteLine($"{hours}:{zero}{minutes}");
        }
    }
}

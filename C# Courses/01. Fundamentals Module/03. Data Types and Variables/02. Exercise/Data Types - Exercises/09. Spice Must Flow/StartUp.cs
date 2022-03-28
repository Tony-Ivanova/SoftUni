namespace _09._Spice_Must_Flow
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            var totalAmount = 0;
            var days = 0;

            var yield = int.Parse(Console.ReadLine());
            var enoughYield = 100;
            var yieldLostPerDay = 10;
            var yieldForWorkers = 26;


            while(yield >= enoughYield)
            {
                totalAmount += yield - yieldForWorkers;
                yield -= yieldLostPerDay;
                days++;
            }

            if (totalAmount!=0)
            {
                totalAmount -= yieldForWorkers;
            }

            Console.WriteLine(days);
            Console.WriteLine(totalAmount);
        }
    }
}

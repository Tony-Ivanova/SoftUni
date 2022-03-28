namespace _07._Water_Overflow
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            var capacity = 255;

            var numberOfLines = int.Parse(Console.ReadLine());

            var pouredWater = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                var water = int.Parse(Console.ReadLine());

                var enoughCapacity = pouredWater + water <= capacity;

                if (enoughCapacity)
                {
                    pouredWater += water;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(pouredWater);
        }
    }
}

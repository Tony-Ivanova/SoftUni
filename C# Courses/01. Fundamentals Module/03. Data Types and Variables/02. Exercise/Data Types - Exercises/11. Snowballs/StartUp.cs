namespace _11._Snowballs
{
    using System;
    using System.Numerics;

    public class StartUp
    {
        public static void Main()
        {
            int snowballsMade = int.Parse(Console.ReadLine());

            int eachSnowball = 0;
            BigInteger max = 0;
            int snow = 0;
            int time = 0;
            int quality = 0;

            for (int i = 1; i <= snowballsMade; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                eachSnowball = (snowballSnow / snowballTime);
                BigInteger temp = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);

                if (temp > max)
                {
                    max = temp;
                    quality = snowballQuality;
                    time = snowballTime;
                    snow = snowballSnow;
                }
            }
            Console.WriteLine($"{snow} : {time} = {max} ({quality}) ");
        }
    }
}

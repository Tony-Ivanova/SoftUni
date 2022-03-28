namespace _10._Poke_Mon
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int pokePower = int.Parse(Console.ReadLine());
            int pokeDistance = int.Parse(Console.ReadLine());
            int pokeExhaustion = int.Parse(Console.ReadLine());

            int target = 0;
            double half = pokePower / 2.0;

            while (pokePower >= pokeDistance)
            {
                pokePower -= pokeDistance;
                target++;
                if (pokePower == half && pokeExhaustion > 0)
                {
                    pokePower /= pokeExhaustion;
                }

            }
            Console.WriteLine($"{pokePower}");
            Console.WriteLine($"{target}");
        }
    }
}

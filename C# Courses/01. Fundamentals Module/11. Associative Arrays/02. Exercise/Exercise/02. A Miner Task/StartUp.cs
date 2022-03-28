namespace _02._A_Miner_Task
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var mining = new Dictionary<string, int>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "stop")
                {
                    break;
                }

                var quantity = int.Parse(Console.ReadLine());

                if (!mining.ContainsKey(input))
                {
                    mining[input] = quantity;
                }
                else
                {
                    mining[input] += quantity;
                }
            }

            foreach (var kvp in mining)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}

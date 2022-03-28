namespace _09._ForceBook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var nameSide = new Dictionary<string, string>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Lumpawaroo")
                {
                    break;
                }

                if (input.Contains("|"))
                {
                    var tokens = input.Split(" | ");
                    var side = tokens[0];
                    var name = tokens[1];

                    if (!nameSide.ContainsKey(name))
                    {
                        nameSide[name] = side;
                    }
                }
                else
                {
                    var tokens = input.Split(" -> ");
                    var name = tokens[0];
                    var side = tokens[1];

                    if (nameSide.ContainsKey(name))
                    {
                        nameSide[name] = side;
                    }
                    else
                    {
                        nameSide[name] = side;
                    }

                    Console.WriteLine($"{name} joins the {side} side!");
                }
            }

            var fillteredNameSide = nameSide
                                    .GroupBy(x => x.Value)
                                    .OrderByDescending(x => x.Count())
                                    .ThenBy(x => x.Key);

            foreach (var kvp in fillteredNameSide)
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Count()}");

                foreach (var kvpValue in kvp.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"! {kvpValue.Key}");
                }
            }
        }
    }
}

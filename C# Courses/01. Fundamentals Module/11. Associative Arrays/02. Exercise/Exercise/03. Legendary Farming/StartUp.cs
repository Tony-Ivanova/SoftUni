namespace _03._Legendary_Farming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var keyMaterials = new Dictionary<string, long>();
            keyMaterials["shards"] = 0;
            keyMaterials["fragments"] = 0;
            keyMaterials["motes"] = 0;

            var junkMaterials = new Dictionary<string, long>();

            var breaks = true;

            while (breaks)
            {
                var input = Console.ReadLine()
                                   .Split()
                                   .ToList();

                for (int i = 0; i < input.Count; i += 2)
                {
                    var quantity = long.Parse(input[i]);
                    var material = input[i + 1].ToLower();

                    if (keyMaterials.ContainsKey(material))
                    {
                        keyMaterials[material] += quantity;
                       
                        if (keyMaterials[material] >= 250)
                        {
                            switch (material)
                            {
                                case "shards":
                                    Console.WriteLine("Shadowmourne obtained!");
                                    break;
                                case "fragments":
                                    Console.WriteLine("Valanyr obtained!");
                                    break;
                                case "motes":
                                    Console.WriteLine("Dragonwrath obtained!");
                                    break;
                            }

                            keyMaterials[material] -= 250;
                            breaks = false;
                            break;
                        }
                    }
                    else
                    {
                        if (!junkMaterials.ContainsKey(material))
                        {
                            junkMaterials[material] = 0;
                        }

                        junkMaterials[material] += quantity;

                    }
                }
            }

            keyMaterials = keyMaterials.OrderBy(x => x.Key).OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            junkMaterials = junkMaterials.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in keyMaterials)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in junkMaterials)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}

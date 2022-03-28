namespace _04._Snowwhite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var dwarfs = new Dictionary<string, int>();
            var colors = new Dictionary<string, int>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Once upon a time")
                {
                    break;
                }

                var tokens = input.Split(new[] { " <:> " }, StringSplitOptions.RemoveEmptyEntries);

                var dwarfName = tokens[0];
                var dwarHatColor = tokens[1];
                var dwarfPhysics = int.Parse(tokens[2]);

                var currentDwarf = $"{dwarfName} <:> {dwarHatColor}";

                if (!colors.ContainsKey(dwarHatColor))
                {
                    colors.Add(dwarHatColor, 1);
                }
                else
                {
                    colors[dwarHatColor]++;
                }

                if (!dwarfs.ContainsKey(currentDwarf))
                {
                    dwarfs.Add(currentDwarf, dwarfPhysics);
                }
                else
                {
                    var oldValue = dwarfs[currentDwarf];

                    if (dwarfPhysics > oldValue)
                    {
                        dwarfs[currentDwarf] = dwarfPhysics;
                    }
                }
            }

            var sortedDwarfs = dwarfs.OrderByDescending(x => x.Value)
                                     .ThenByDescending(x => colors[x.Key.Split(new[] { " <:> " }, 
                                     StringSplitOptions.RemoveEmptyEntries)[1]])
                                     .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in sortedDwarfs)
            {
                var dwarfId = item.Key;
                var physics = item.Value;
                var dwarfIDTokens = dwarfId.Split(new[] { " <:> " }, StringSplitOptions.RemoveEmptyEntries);
                var dwarfName = dwarfIDTokens[0];
                var dwarfHatColor = dwarfIDTokens[1];

                Console.WriteLine($"({dwarfHatColor}) {dwarfName} <-> {physics}");
            }
        }
    }
}

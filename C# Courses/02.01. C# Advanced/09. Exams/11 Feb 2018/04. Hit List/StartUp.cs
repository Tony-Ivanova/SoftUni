namespace Hit_List
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var target = int.Parse(Console.ReadLine());

            var myDict = new Dictionary<string, Dictionary<string, string>>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "end transmissions")
                {
                    break;
                }

                var tokens = input.Split('=');
                var name = tokens[0];

                if (!myDict.ContainsKey(name))
                {
                    myDict[name] = new Dictionary<string, string>();
                }

                foreach (var item in tokens[1].Split(';'))
                {
                    var currentKVP = item.Split(':');
                    var key = currentKVP[0];
                    var value = currentKVP[1];

                    if (!myDict[name].ContainsKey(key))
                    {
                        myDict[name][key] = "";
                    }

                    myDict[name][key] = value;
                }
            }

            var whoToKill = Console.ReadLine().Split()[1];

            Console.WriteLine($"Info on {whoToKill}:");

            var sumKeys = 0;
            var sumValues = 0;

            foreach (var item in myDict[whoToKill].OrderBy(x => x.Key))
            {
                Console.WriteLine($"---{item.Key}: {item.Value}");
                sumKeys += item.Key.Count();
                sumValues += item.Value.Count();
            }

            var sum = sumValues + sumKeys;

            Console.WriteLine($"Info index: {sum}");

            if (sum >= target)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {target - sum} more info.");
            }
        }
    }
}
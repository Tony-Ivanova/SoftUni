namespace _03._Greedy_Times
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            long capacity = long.Parse(Console.ReadLine());

            var myDict = new Dictionary<string, Dictionary<string, long>>();
           
            myDict["Gold"] = new Dictionary<string, long>();
            myDict["Gem"] = new Dictionary<string, long>();
            myDict["Cash"] = new Dictionary<string, long>();

            var amount = 0L;
            var goldAmount = 0L;
            var gemAmount = 0L;
            var cashAmount = 0L;


            var input = Console.ReadLine()
                               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i += 2)
            {
                var key = input[i];
                var value = long.Parse(input[i + 1]);

                if (amount + value > capacity)
                {
                    continue;
                }

                if (key.ToLower() == "gold")
                {
                    if (goldAmount + value >= gemAmount)
                    {
                        if (!myDict["Gold"].ContainsKey(key))
                        {
                            myDict["Gold"][key] = 0;
                        }

                        myDict["Gold"][key] += value;
                        amount += value;
                        goldAmount += value;
                    }
                }

                else if (key.Length >= 4 && key.ToLower().EndsWith("gem"))
                {
                    if (gemAmount + value >= cashAmount && goldAmount >= gemAmount + value)
                    {
                        if (!myDict["Gem"].ContainsKey(key))
                        {
                            myDict["Gem"][key] = 0;
                        }

                        myDict["Gem"][key] += value;
                        amount += value;
                        gemAmount += value;
                    }
                }

                var result = key.All(char.IsLetter);

                if (key.Length == 3 && result == true)
                {
                    if (gemAmount >= cashAmount + value)
                    {
                        if (!myDict["Cash"].ContainsKey(key))
                        {
                            myDict["Cash"][key] = 0;
                        }

                        myDict["Cash"][key] += value;

                        amount += value;
                        cashAmount += value;
                    }
                }
            }

            foreach (var item in myDict.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Value.Sum(kvp => kvp.Value)))
            {
                Console.WriteLine($"<{item.Key}> ${item.Value.Sum(kvp => kvp.Value)}");

                foreach (var kvp in item.Value.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                {
                    Console.WriteLine($"##{kvp.Key} - {kvp.Value}");
                }
            }
        }
    }
}

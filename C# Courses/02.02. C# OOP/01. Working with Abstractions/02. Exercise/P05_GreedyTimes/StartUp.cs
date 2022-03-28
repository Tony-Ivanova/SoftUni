namespace P05_GreedyTimes
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());

            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Bag(capacity);

            for (int i = 0; i < input.Length; i += 2)
            {
                string key = input[i];
                long value = long.Parse(input[i + 1]);

                InsertItem(key, value, bag);
            }

            Console.WriteLine(bag.ToString());

        }

        private static void InsertItem(string key, long value, Bag bag)
        {
            if (key.Length == 3)
            {
                var cash = new Cash(key, value);
                bag.AddCash(cash);
            }
            else if (key.ToLower().EndsWith("gem"))
            {
                var gem = new Gem(key, value);
                bag.AddGem(gem);
            }
            else if (key.ToLower() == "gold")
            {
                var gold = new Gold(key, value);
                bag.AddGold(gold);
            }
        }
    }
}
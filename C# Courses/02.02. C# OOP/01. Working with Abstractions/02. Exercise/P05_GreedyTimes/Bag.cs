namespace P05_GreedyTimes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Bag
    {
        private List<Items> bag;
        private long capacity;
        private long current;

        public Bag(long capacity)
        {
            this.capacity = capacity;
            bag = new List<Items>();
        }
        public long GoldItemsValue
        {
            get
            {
                return bag.Where(i => i is Gold).Sum(i => i.Value);
            }
        }

        public long CashItemsValue
        {
            get
            {
                return bag.Where(i => i is Cash).Sum(i => i.Value);
            }
        }

        public long GemItemsValue
        {
            get
            {
                return bag.Where(i => i is Gem).Sum(i => i.Value);
            }
        }

        public void AddGold(Gold gold)
        {
            if (capacity >= current + gold.Value)
            {
                var goldItems = GetGoldItems();

                if (goldItems.Any(x => x.Key == gold.Key))
                {
                    goldItems.Single(x => x.Key == x.Key).IncreasingValue(gold.Value);
                }
                else
                {
                    bag.Add(gold);
                }

                current += gold.Value;
            }
        }

        public void AddGem(Gem gem)
        {
            if (capacity >= current + gem.Value && GoldItemsValue >= GemItemsValue + gem.Value)
            {
                var gemItems = GetGemItems();

                if (gemItems.Any(x => x.Key == gem.Key))
                {
                    gemItems.Single(x => x.Key == gem.Key).IncreasingValue(gem.Value);
                }
                else
                {
                    bag.Add(gem);
                }
                current += gem.Value;
            }
        }

        public void AddCash(Cash cash)
        {
            if (capacity >= current + cash.Value && GemItemsValue >= CashItemsValue + cash.Value)
            {
                var cashItems = GetCashItems();
                if (cashItems.Any(x => x.Key == cash.Key))
                {
                    cashItems.Single(x => x.Key == cash.Key).IncreasingValue(cash.Value);
                }
                else
                {
                    bag.Add(cash);
                }
                current += cash.Value;
            }
        }

        public List<Items> GetCashItems()
        {
            return bag.Where(i => i is Cash).ToList();
        }

        public List<Items> GetGoldItems()
        {
            return bag.Where(i => i is Gold).ToList();
        }

        public List<Items> GetGemItems()
        {
            return bag.Where(i => i is Gem).ToList();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            var dictionary = bag.GroupBy(x => x.GetType().Name).ToDictionary(y => y.Key, y => y.ToList());

            foreach (var kvp in dictionary.OrderByDescending(kv => kv.Value.Sum(i => i.Value)))
            {
                if (kvp.Key == "Cash")
                {
                    builder.AppendLine($"<Cash> ${kvp.Value.Sum(i => i.Value)}");
                }
                else if (kvp.Key == "Gem")
                {
                    builder.AppendLine($"<Gem> ${kvp.Value.Sum(i => i.Value)}");
                }
                else if (kvp.Key == "Gold")
                {
                    builder.AppendLine($"<Gold> ${kvp.Value.Sum(i => i.Value)}");
                }

                foreach (var item in kvp.Value.OrderByDescending(i => i.Key).ThenBy(i => i.Value))
                {
                    builder.AppendLine($"##{item.Key} - {item.Value}");
                }
            }

            return builder.ToString().TrimEnd();
        }
    }
}
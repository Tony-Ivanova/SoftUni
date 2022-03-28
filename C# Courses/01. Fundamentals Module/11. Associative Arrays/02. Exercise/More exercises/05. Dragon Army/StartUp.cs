namespace _05._Dragon_Army
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            var dragons = new Dictionary<string, Dictionary<string, List<double>>>();
            
            for (int i = 0; i < number; i++)
            {
                var tokens = Console.ReadLine()
                                    .Split()
                                    .ToArray();

                var type = tokens[0];
                var name = tokens[1];
                var damageString = tokens[2];
                var healthString = tokens[3];
                var armorString = tokens[4];
            
                if (healthString == "null")
                {
                    healthString = "250";
                }

                if (damageString == "null")
                {
                    damageString = "45";
                }

                if (armorString == "null")
                {
                    armorString = "10";
                }

                var damage = double.Parse(damageString);
                var health = double.Parse(healthString);
                var armor = double.Parse(armorString);

                if (!dragons.ContainsKey(type))
                {
                    dragons.Add(type, new Dictionary<string, List<double>>());
                }

                if (!dragons[type].ContainsKey(name))
                {
                    dragons[type].Add(name, new List<double>());
                    dragons[type][name].Add(damage);
                    dragons[type][name].Add(health);
                    dragons[type][name].Add(armor);
                }
                else
                {
                    dragons[type][name].Clear();
                    dragons[type][name].Add(damage);
                    dragons[type][name].Add(health);
                    dragons[type][name].Add(armor);
                }
            }

            foreach (var dragon in dragons)
            {
                string type = dragon.Key;
                double damage = 0;
                double health = 0;
                double armor = 0;
                double count = 0;

                foreach (var quality in dragon.Value)
                {
                    var name = quality.Key;
                    var dragonQuality = quality.Value;
                    damage += dragonQuality[0];
                    health += dragonQuality[1];
                    armor += dragonQuality[2];
                    count++;
                }

                Console.WriteLine($"{type}::({damage / count:f2}/{health / count:f2}/{armor / count:f2})");

                foreach (var item in dragon.Value.OrderBy(x => x.Key))
                {
                    List<double> dragonQuality = item.Value;
                    Console.WriteLine($"-{item.Key} -> damage: {dragonQuality[0]}, health: {dragonQuality[1]}, armor: {dragonQuality[2]}");
                }
            }
        }
    }
}

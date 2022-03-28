namespace _03._Raiding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private ICollection<BaseHero> heroes;

        public Engine()
        {
            heroes = new List<BaseHero>();
        }

        public void Run()
        {
            int lines = int.Parse(Console.ReadLine());

            int counter = 0;

            while (lines != counter)
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    var hero = HeroFactory.CreateHero(name, heroType);
                    heroes.Add(hero);
                    counter++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            double bossPower = double.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int sum = heroes.Sum(h => h.Power);

            if (sum >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
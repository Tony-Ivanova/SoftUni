namespace _09._Pokemon_Trainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Trainer> trainers = new List<Trainer>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Tournament")
                {
                    break;
                }

                string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonType = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Trainer currentTrainer = new Trainer(trainerName);
                Pokemon currentPokemon = new Pokemon(pokemonName, pokemonType, pokemonHealth);

                currentTrainer.Pokemons.Add(currentPokemon);

                bool wasAdded = false;
                foreach (var trainer in trainers)
                {
                    if (trainer.Name == trainerName)
                    {
                        trainer.Pokemons.Add(currentPokemon);
                        wasAdded = true;
                        break;
                    }
                }
                if (!wasAdded)
                    trainers.Add(currentTrainer);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                for (int i = 0; i < trainers.Count; i++)
                {
                    Trainer currentTrainer = trainers[i];
                    if (currentTrainer.ContainsType(input))
                    {
                        currentTrainer.NumberOfBadges++;
                    }
                    else
                    {
                        currentTrainer.DecreaseHealth();
                    }
                }
            }

            trainers = trainers.OrderByDescending(trainer => trainer.NumberOfBadges).ToList();
            foreach (var trainer in trainers)
            {
                Console.WriteLine(trainer.ToString());
            }
        }
    }
}

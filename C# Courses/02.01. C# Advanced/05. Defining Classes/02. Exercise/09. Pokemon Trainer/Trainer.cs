namespace _09._Pokemon_Trainer
{
    using System.Collections.Generic;
    public class Trainer
    {
        public string Name;
        public int NumberOfBadges;
        public List<Pokemon> Pokemons;

        public Trainer(string name)
        {
            Name = name;
            NumberOfBadges = 0;
            Pokemons = new List<Pokemon>();
        }

        public bool ContainsType(string element)
        {
            foreach (var pokemon in Pokemons)
            {
                if (pokemon.Element == element)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddPokemon(Pokemon pokemon)
        {
            Pokemons.Add(pokemon);
        }

        public void DecreaseHealth()
        {
            for (int i = 0; i < Pokemons.Count; i++)
            {
                if (Pokemons[i].Health - 10 > 0)
                {
                    Pokemons[i].Health -= 10;
                }
                else
                {
                    Pokemons.Remove(Pokemons[i]);
                }
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.NumberOfBadges} {this.Pokemons.Count}";
        }
    }
}

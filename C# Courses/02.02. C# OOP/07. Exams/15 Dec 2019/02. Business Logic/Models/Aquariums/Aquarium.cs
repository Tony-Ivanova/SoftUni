using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private IList<IDecoration> decorations;
        private IList<IFish> fishes;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fishes = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                this.capacity = value;
            }
        }

        public int Comfort => this.decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fishes;

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if(this.Capacity - 1 <= 0)
            {
                this.Capacity = 0;
                throw new InvalidOperationException("Not enough capacity.");
            }
            this.Capacity -= 1;
            fishes.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in fishes)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();
            var fishNames = fishes.Select(x => x.Name).ToList();
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            sb.AppendLine($"Fish: {(fishes.Count == 0 ? "None" : string.Join(", ", fishNames))}");
            sb.AppendLine($"Decorations: {decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");
            return sb.ToString();
        }

        public bool RemoveFish(IFish fish)
        {
            IFish fishToBeRemoved = null;
            if (fishes.Contains(fish))
            {
                fishToBeRemoved = fish;
            }
            return fishes.Remove(fishToBeRemoved);
        }
    }
}

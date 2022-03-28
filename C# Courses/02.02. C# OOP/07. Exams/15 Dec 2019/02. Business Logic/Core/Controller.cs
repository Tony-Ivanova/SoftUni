using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorationRepository;
        private IDictionary<string, IAquarium> aquariums;
        private IList<IDecoration> decorations;
        public Controller()
        {
            this.aquariums = new Dictionary<string, IAquarium>();
            this.decorations = new List<IDecoration>();
            this.decorationRepository = new DecorationRepository();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {            
            
            if(aquariumType == "FreshwaterAquarium")
            {
                aquariums.Add(aquariumName, new FreshwaterAquarium(aquariumName));
                
            }
            else if(aquariumType == "SaltwaterAquarium")
            {
                aquariums.Add(aquariumName, new SaltwaterAquarium(aquariumName));
                
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }

            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decorationToAdd = null;

            if(decorationType == "Ornament")
            {
                decorationToAdd = new Ornament();
            }
            else if(decorationType == "Plant")
            {
                decorationToAdd = new Plant();
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }
            decorations.Add(decorationToAdd);
            decorationRepository.Add(decorationToAdd);

            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var aquarium = aquariums[aquariumName];
            IFish fish = null;
            var message = string.Empty;

            if(fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if(fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            if((aquarium.GetType().Name == "FreshwaterAquarium" && fish.GetType().Name != "FreshwaterFish")
                || (aquarium.GetType().Name == "SaltwaterAquarium" && fish.GetType().Name != "SaltwaterFish"))
            {
                message = "Water not suitable.";
            }
            else
            {
                aquarium.AddFish(fish);
                message = $"Successfully added {fishType} to {aquariumName}.";
            }

            return message;

        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = aquariums[aquariumName];

            var value = aquarium.Decorations.Sum(x => x.Price) + aquarium.Fish.Sum(x => x.Price);

            return $"The value of Aquarium {aquariumName} is {value:F2}.";
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariums[aquariumName];
            foreach (var fish in aquarium.Fish)
            {
                fish.Eat();
            }
            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = decorationRepository.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            if(aquariums.ContainsKey(aquariumName) && decorationRepository.FindByType(decorationType) != null)
            {
                var aquarium = aquariums[aquariumName];                
                aquarium.AddDecoration(decoration);
                decorationRepository.Remove(decoration);
            }

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var kvp in aquariums)
            {                
               
                    sb.Append(kvp.Value.GetInfo());
               
            }

            return sb.ToString().TrimEnd();
        }
    }
}

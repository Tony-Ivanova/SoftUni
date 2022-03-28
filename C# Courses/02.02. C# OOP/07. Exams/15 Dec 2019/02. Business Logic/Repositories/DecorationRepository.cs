using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private ICollection<IDecoration> decorationRepository;

        public DecorationRepository()
        {
            this.decorationRepository = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this.decorationRepository.ToList().AsReadOnly();

        public void Add(IDecoration model)
        {
            decorationRepository.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            IDecoration decoration = null;

            if (type == "Ornament")
            {
                decoration = decorationRepository.FirstOrDefault(x=>x.GetType().Name == "Ornament");
            }
            else if(type == "Plant")
            {
                decoration = decorationRepository.FirstOrDefault(x => x.GetType().Name == "Plant");
            }

            return decoration;
        }

        public bool Remove(IDecoration model)
        {
            if (this.decorationRepository.Contains(model))
            {
                this.decorationRepository.Remove(model);

                return true;
            }

            else
            {
                return false;
            }
        }
    }
}

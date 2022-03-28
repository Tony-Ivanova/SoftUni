namespace SantaWorkshop.Repositories
{
    using SantaWorkshop.Models.Presents.Contracts;
    using SantaWorkshop.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class PresentRepository : IRepository<IPresent>
    {
        private IDictionary<string, IPresent> presentRepository;

        public PresentRepository()
        {
            this.presentRepository = new Dictionary<string, IPresent>();
        }

        public IReadOnlyCollection<IPresent> Models => this.presentRepository.Values.ToList().AsReadOnly();

        public void Add(IPresent model)
        {
            this.presentRepository.Add(model.Name, model);
        }

        public IPresent FindByName(string name)
        {
            IPresent present = null;

            if (presentRepository.ContainsKey(name))
            {
                present = presentRepository[name];
            }

            return present;
        }

        public bool Remove(IPresent model)
        {
            IPresent present = null;
            if (presentRepository.ContainsKey(model.Name))
            {
                present = presentRepository[model.Name];
            }

            return this.presentRepository.Remove(present.Name);
        }
    }
}

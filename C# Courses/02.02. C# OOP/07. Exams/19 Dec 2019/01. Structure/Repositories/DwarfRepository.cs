namespace SantaWorkshop.Repositories
{
    using SantaWorkshop.Models.Dwarfs.Contracts;
    using SantaWorkshop.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class DwarfRepository : IRepository<IDwarf>
    {
        private readonly IDictionary<string, IDwarf> dwarfRepository;

        public DwarfRepository()
        {
            dwarfRepository = new Dictionary<string, IDwarf>();
        }

        public IReadOnlyCollection<IDwarf> Models => this.dwarfRepository.Values.ToList().AsReadOnly();

        public void Add(IDwarf model)
        {
            var nameDwarf = model.Name;
            dwarfRepository[nameDwarf] = model;
        }

        public IDwarf FindByName(string name)
        {
            IDwarf dwarf = null;

            if (dwarfRepository.ContainsKey(name))
            {
                dwarf = dwarfRepository[name];
            }

            return dwarf;
        }

        public bool Remove(IDwarf model)
        {
            IDwarf dwarf = null;

            if (dwarfRepository.ContainsKey(model.Name))
            {
                dwarf = dwarfRepository[model.Name];
            }

            return this.dwarfRepository.Remove(dwarf.Name);
        }
    }
}

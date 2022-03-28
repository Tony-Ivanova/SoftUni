namespace SantaWorkshop.Models.Dwarfs
{
    using SantaWorkshop.Models.Dwarfs.Contracts;
    using SantaWorkshop.Models.Instruments.Contracts;
    using System;
    using System.Collections.Generic;

    public abstract class Dwarf : IDwarf
    {
        private string name;
        private int energy;
        private IList<IInstrument> instruments;

        protected Dwarf(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.instruments = new List<IInstrument>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Dwarf name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.energy = value;
            }
        }

        public ICollection<IInstrument> Instruments => this.instruments;

        public void AddInstrument(IInstrument instrument)
        {
            instruments.Add(instrument);
        }

        public abstract void Work();
    }
}

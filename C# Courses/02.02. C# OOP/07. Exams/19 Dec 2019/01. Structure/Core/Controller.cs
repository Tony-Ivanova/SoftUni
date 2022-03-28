namespace SantaWorkshop.Core
{
    using SantaWorkshop.Core.Contracts;
    using SantaWorkshop.Models.Dwarfs;
    using SantaWorkshop.Models.Dwarfs.Contracts;
    using SantaWorkshop.Models.Instruments;
    using SantaWorkshop.Models.Instruments.Contracts;
    using SantaWorkshop.Models.Presents;
    using SantaWorkshop.Models.Presents.Contracts;
    using SantaWorkshop.Models.Workshops;
    using SantaWorkshop.Models.Workshops.Contracts;
    using SantaWorkshop.Repositories;
    using SantaWorkshop.Repositories.Contracts;
    using SantaWorkshop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private IRepository<IPresent> presents;
        private IRepository<IDwarf> dwarfs;
        private IList<IDwarf> dwarfsListedToWork;
        private IList<IPresent> presentsCrafted;
        private IWorkshop workshop;

        public Controller()
        {
            this.presents = new PresentRepository();
            this.dwarfs = new DwarfRepository();
            this.dwarfsListedToWork = new List<IDwarf>();
            this.presentsCrafted = new List<IPresent>();
            this.workshop = new Workshop();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {

            if (dwarfType == "HappyDwarf")
            {
                var dwarf = new HappyDwarf(dwarfName);
                dwarfs.Add(dwarf);
                dwarfsListedToWork.Add(dwarf);

            }
            else if (dwarfType == "SleepyDwarf")
            {
                var dwarf = new SleepyDwarf(dwarfName);
                dwarfs.Add(dwarf);
                dwarfsListedToWork.Add(dwarf);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidDwarfType));
            }

            return string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            IInstrument instrument = new Instrument(power);
            IDwarf dwarf = null;

            if (dwarfs.FindByName(dwarfName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDwarf));
            }
            else
            {
                dwarf = dwarfs.FindByName(dwarfName);
                dwarf.AddInstrument(instrument);
            }

            return string.Format(OutputMessages.InstrumentAdded, instrument.Power, dwarf.Name);
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            IPresent present = new Present(presentName, energyRequired);
            presents.Add(present);

            return string.Format(OutputMessages.PresentAdded, present.Name);
        }

        public string CraftPresent(string presentName)
        {
            var suitableDwarfs = dwarfsListedToWork.Where(x => x.Energy >= 50).OrderByDescending(x => x.Energy).ToList();
            var present = presents.FindByName(presentName);


            if (suitableDwarfs.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }

            foreach (var dwarf in suitableDwarfs)
            {
                workshop.Craft(present, dwarf);

                if (dwarf.Energy == 0)
                {
                    dwarfs.Remove(dwarf);
                    break;
                }

                else if (present.IsDone())
                {
                    presentsCrafted.Add(present);
                    break;
                }
            }

            return $"Present {presentName} is {(present.IsDone() == true ? "done" : "not done")}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{presentsCrafted.Count} presents are done!");
            sb.AppendLine("Dwarfs info:");
            foreach (var dwarf in dwarfsListedToWork)
            {
                sb.AppendLine($"Name: {dwarf.Name}");
                sb.AppendLine($"Energy: {dwarf.Energy}");
                sb.AppendLine($"Instruments: {dwarf.Instruments.Count(x => x.IsBroken() == false)} not broken left");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

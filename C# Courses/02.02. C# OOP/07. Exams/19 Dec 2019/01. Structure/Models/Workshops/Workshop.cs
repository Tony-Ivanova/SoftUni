namespace SantaWorkshop.Models.Workshops
{
    using SantaWorkshop.Models.Dwarfs.Contracts;
    using SantaWorkshop.Models.Presents.Contracts;
    using SantaWorkshop.Models.Workshops.Contracts;

    public class Workshop : IWorkshop
    {
        public Workshop()
        {
        }

        public void Craft(IPresent present, IDwarf dwarf)
        {
            var instruments = dwarf.Instruments;

            foreach (var instrument in instruments)
            {
                while (true)
                {
                    if (dwarf.Energy < 0 || instrument.IsBroken() || present.IsDone())
                    {
                        break;
                    }

                    instrument.Use();
                    dwarf.Work();
                    present.GetCrafted();
                }

            }
        }
    }
}

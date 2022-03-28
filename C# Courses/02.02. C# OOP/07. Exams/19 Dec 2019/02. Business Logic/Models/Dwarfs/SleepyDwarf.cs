namespace SantaWorkshop.Models.Dwarfs
{
    public class SleepyDwarf : Dwarf
    {
        private const int InitialEnergy = 50;

        public SleepyDwarf(string name) 
            : base(name, InitialEnergy)
        {
        }

        public override void Work()
        {
            if (this.Energy - 15 <= 0)
            {
                this.Energy = 0;
            }

            this.Energy -= 15;
        }
    }
}

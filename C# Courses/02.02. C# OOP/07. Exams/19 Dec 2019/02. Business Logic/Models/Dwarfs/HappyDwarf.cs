namespace SantaWorkshop.Models.Dwarfs
{
    public class HappyDwarf : Dwarf
    {
        private const int InitialEnergy = 100;

        public HappyDwarf(string name) 
            : base(name, InitialEnergy)
        {
        }

        public override void Work()
        {
            if(this.Energy - 10 <= 0)
            {
                this.Energy = 0;
            }
            this.Energy -= 10;
        }
    }
}

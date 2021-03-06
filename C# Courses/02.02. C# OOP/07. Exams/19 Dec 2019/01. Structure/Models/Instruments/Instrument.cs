namespace SantaWorkshop.Models.Instruments
{
    using SantaWorkshop.Models.Instruments.Contracts;
   
    public class Instrument : IInstrument
    {
        private int power;

        public Instrument(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get => this.power;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.power = value;
            }
        }

        public bool IsBroken() => this.Power == 0;

        public void Use()
        {
            if (this.Power - 10 < 0)
            {
                this.Power = 0;
            }
            else
            {
                this.Power -= 10;
            }
        }
    }
}

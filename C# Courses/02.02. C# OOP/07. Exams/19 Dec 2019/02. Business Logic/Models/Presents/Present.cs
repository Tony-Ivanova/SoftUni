namespace SantaWorkshop.Models.Presents
{
    using SantaWorkshop.Models.Presents.Contracts;
    using System;
   
    public class Present : IPresent
    {
        private string name;
        private int energyRequired;

        public Present(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Present name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get => this.energyRequired;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.energyRequired = value;
            }
        }


        public void GetCrafted()
        {
            if (energyRequired - 10 >= 0)
            {
                this.EnergyRequired -= 10;
            }
        }

        public bool IsDone() => this.energyRequired == 0;
    }
}

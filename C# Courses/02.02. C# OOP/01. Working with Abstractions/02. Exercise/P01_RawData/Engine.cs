namespace P01_RawData
{
    using P01_RawData.Data;
    using P01_RawData.Factory;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private IDataReaders dataReaders;
        private IDataWriter dataWriter;

        public Engine(
            IDataReaders dataReaders,
            IDataWriter dataWriter)
        {
            this.dataReaders = dataReaders;
            this.dataWriter = dataWriter;
        }

        public void Run()
        {
            EngineFactory engineFactory = new EngineFactory();
            CargoFactory cargoFactory = new CargoFactory();
            CarFactory carFactory = new CarFactory();

            CarCatalog carCatalog = new CarCatalog(engineFactory, cargoFactory, carFactory);

            int lines = int.Parse(dataReaders.Read());
           
            for (int i = 0; i < lines; i++)
            {
                string[] parameters = dataReaders.Read().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                carCatalog.Add(parameters);
            }

            string command = dataReaders.Read();

            if (command == "fragile")
            {
                List<string> fragile = carCatalog.GetCars()
                    .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                dataWriter.Write(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = carCatalog.GetCars()
                    .Where(x => x.Cargo.CargoType == "flamable" && x.CarEngine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                dataWriter.Write(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}

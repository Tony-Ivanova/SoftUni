namespace P01_RawData
{
    using CarProperties;
    using P01_RawData.Factory;
    using System.Collections.Generic;
    using System.Linq;

    public class CarCatalog
    {
        private List<Car> cars;
        private EngineFactory engineFactory;
        private CargoFactory cargoFactory;
        private CarFactory carFactory;

        private const int tireCount = 4;

        public CarCatalog(EngineFactory engineFactory, CargoFactory cargoFactory, CarFactory carFactory)
        {
            this.cars = new List<Car>();
            this.engineFactory = engineFactory;
            this.cargoFactory = cargoFactory;
            this.carFactory = carFactory;
        }

        public void Add(string[] parameters)
        {
            string model = parameters[0];
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];

            CarEngine carEngine = engineFactory.Create(engineSpeed, enginePower);
            Cargo cargo = cargoFactory.Create(cargoWeight, cargoType);
            Tire[] tires = GetTires(parameters.Skip(5).ToList());

            Car car = carFactory.Create(model, carEngine, cargo, tires);

            cars.Add(car);
        }

        private Tire[] GetTires(List<string> tireParameters)
        {
            Tire[] tires = new Tire[tireCount];

            int currentTireIndex = 0;

            for (int tireIndex = 0; tireIndex < 8; tireIndex += 2)
            {
                double tirePressure = double.Parse(tireParameters[tireIndex]);
                int tireAge = int.Parse(tireParameters[tireIndex + 1]);

                Tire tire = new Tire(tirePressure, tireAge);

                tires[currentTireIndex] = tire;

                currentTireIndex++;
            }

            return tires;
        }

        public List<Car> GetCars()
        {
            return this.cars;
        }
    }
}

using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository driverRepository;
        private CarRepository carRepository;
        private RaceRepository raceRepository;


        public ChampionshipController()
        {
            this.driverRepository = new DriverRepository();
            this.carRepository = new CarRepository();
            this.raceRepository = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            ICar car = carRepository.GetByName(carModel);
            IDriver driver = driverRepository.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            else if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = raceRepository.GetByName(raceName);
            IDriver driver = driverRepository.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (carRepository.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            ICar car = null;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            carRepository.Add(car);

            return string.Format(OutputMessages.CarCreated, $"{type}Car", model);
        }

        public string CreateDriver(string driverName)
        {
            if (driverRepository.GetByName(driverName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            IDriver driver = new Driver(driverName);

            this.driverRepository.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driver.Name);
        }

        public string CreateRace(string name, int laps)
        {
            if (raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, laps));
            }

            IRace race = new Race(name, laps);
            raceRepository.Add(race);
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            List<IDriver> top3drivers = race.Drivers.OrderByDescending(x=>x.Car.CalculateRacePoints(race.Laps)).ToList();

            var firstDriver = top3drivers[0];
            var secondDriver = top3drivers[1];
            var thirdDriver = top3drivers[2];

            raceRepository.Remove(race);
            return string.Format(OutputMessages.DriverFirstPosition, firstDriver.Name, raceName) + Environment.NewLine + string.Format(OutputMessages.DriverSecondPosition, secondDriver.Name, raceName) + Environment.NewLine + string.Format(OutputMessages.DriverThirdPosition, thirdDriver.Name, raceName);
        }
    }
}

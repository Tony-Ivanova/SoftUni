using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        private UnitDriver driver;
        private UnitCar car;


        [SetUp]
        public void Setup()
        {
            car = new UnitCar("Nqkakva", 200, 300);
            driver = new UnitDriver("Nqkoi", car);
        }

        [Test]
        public void SuccessfullyAddDriver()
        {
            RaceEntry raceEntity = new RaceEntry();
            raceEntity.AddDriver(driver);
            Assert.AreEqual(1, raceEntity.Counter);
        }

        [Test]
        public void NoSuchDriver()
        {
            RaceEntry raceEntity = new RaceEntry();
            UnitDriver driver = null;
            Assert.Throws<InvalidOperationException>(() => raceEntity.AddDriver(driver));
        }

        [Test]
        public void DiverIsAlreadyAdded()
        {
            RaceEntry raceEntity = new RaceEntry();
            raceEntity.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() => raceEntity.AddDriver(driver));
        }

        [Test]
        public void NotEnoughParticipants()
        {
            RaceEntry raceEntity = new RaceEntry();
            raceEntity.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() => raceEntity.CalculateAverageHorsePower());
        }

        [Test]
        public void ReturnCorrectCC()
        {
            RaceEntry raceEntity = new RaceEntry();
            raceEntity.AddDriver(driver);

            var secondDriver = new UnitDriver("Nqkakyw", car);
            raceEntity.AddDriver(secondDriver);
            var thirdDriver = new UnitDriver("NqkojSi", car);
            raceEntity.AddDriver(thirdDriver);
            var expectedResult = 200;

            Assert.AreEqual(expectedResult, raceEntity.CalculateAverageHorsePower());
        }
    }
}
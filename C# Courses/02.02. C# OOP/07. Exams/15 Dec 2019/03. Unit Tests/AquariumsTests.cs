namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        private string aquariumName = "Neshto si";
        private int capacity = 2;
        private List<Fish> fish;

        [SetUp]
        public void SetUp()
        {
            this.aquarium = new Aquarium(aquariumName, capacity);
        }

        [Test]
        public void Constructor_Works_Correctly()
        {
            Assert.AreEqual(aquariumName, aquarium.Name);
            Assert.AreEqual(capacity, aquarium.Capacity);
        }

        [Test]
        public void Null_Name_Throws_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, capacity));
        }
                     
        [Test]
        public void Correct_Name_Works_Great()
        {
            Assert.AreEqual("Neshto si", aquarium.Name);
        }

        [Test]
        public void When_Capacity_Is_Null_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium(aquariumName, -10));
        }

        [Test]
        public void Capacity_Works_Great()
        {
            Assert.AreEqual(2, aquarium.Capacity);
        }

        [Test]
        public void Should_Return_Correct_Count()
        {
            var fish = new Fish("Nemo");
            aquarium.Add(fish);           
            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void Not_Enough_Capacity_Should_Throw_Exception()
        {
            var fish = new Fish("Nemo");
            aquarium.Add(fish);
            aquarium.Add(new Fish("Second"));
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Third")));
        }

        [Test]
        public void Removing_Missing_Fish_Throws_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Third"));
        }

        [Test]
        public void Sell_Missing_Fish_Throws_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Third"));
        }

        [Test]
        public void Returns_Correct_Report()
        {
            aquarium.Add(new Fish("Nemo"));            
            string expectedResult = $"Fish available at Neshto si: Nemo";
            Assert.AreEqual(expectedResult, aquarium.Report());
        }

        [Test]
        public void Returns_Correct_Sold_Fish()
        {
            var fish = new Fish("Nemo");
            aquarium.Add(fish);
            Assert.AreEqual(fish, aquarium.SellFish("Nemo"));
        }

       

    }
}
